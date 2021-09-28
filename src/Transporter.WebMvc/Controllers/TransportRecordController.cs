using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Transporter.Administration.Application.Service;
using Transporter.Transport.Application.Service;
using Transporter.Transport.Application.ViewModels;

namespace Transporter.WebMvc.Controllers
{
    [Authorize]
    public class TransportRecordController : Controller
    {
        private readonly ITransportAppService _transportAppService;
        private readonly IUserAppService _userAppService;

        public TransportRecordController(ITransportAppService vehicleAppService, IUserAppService userAppService)
        {
            _transportAppService = vehicleAppService;
            _userAppService = userAppService;
        }

        public IActionResult CreateTransportRecord()
        {
            return View();
        }

        public IActionResult IndexReport()
        {
            var dados = _transportAppService.MakeReport(DateTime.MinValue, DateTime.MinValue);

            return View("IndexReport", dados);
        }

        [HttpPost]
        public IActionResult GetReport(DateTime dateStart, DateTime dateEnd)
        {
            var dados = _transportAppService.MakeReport(dateStart, dateEnd);

            return PartialView("GetReport", dados);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTransportRecord(TransportRecordViewModel transportRecordViewModel)
        {
            var vehicle = _transportAppService.FindVehicleByLicensePlate(transportRecordViewModel.LicensePlate);

            if (vehicle == null)
            {
                ViewBag.TheResult = false;
                ViewBag.MsgResult = "Placa do veículo não cadastrada.";
                return View("CreateTransportRecord");
            }

            var person = _userAppService.FindPersonByCpf(transportRecordViewModel.CpfPassenger);
            if (person == null)
            {
                ViewBag.TheResult = false;
                ViewBag.MsgResult = "Cpf não cadastrado.";
                return View("CreateTransportRecord");
            }

            var personIsPassenger = _userAppService.FindPassengerByPersonId(person.Id) != null;

            if (!personIsPassenger)
            {
                ViewBag.TheResult = false;
                ViewBag.MsgResult = "O CPF informado não é de um passageiro.";
                return View("CreateTransportRecord");
            }

            ViewBag.TheResult = true;
            transportRecordViewModel.VehicleId = vehicle.Id;
            await _transportAppService.AddTransportRecord(transportRecordViewModel);

            return View("CreateTransportRecord");
        }
    }
}
