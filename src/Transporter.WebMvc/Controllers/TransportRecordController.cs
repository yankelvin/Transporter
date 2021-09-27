using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Transporter.Administration.Application.Service;
using Transporter.Transport.Application.Service;
using Transporter.Transport.Application.ViewModels;

namespace Transporter.WebMvc.Controllers
{
    public class TransportRecordController : Controller
    {
        private readonly ITransportAppService _vehicleAppService;
        private readonly IUserAppService _userAppService;

        public TransportRecordController(ITransportAppService vehicleAppService, IUserAppService userAppService)
        {
            _vehicleAppService = vehicleAppService;
            _userAppService = userAppService;
        }

        public IActionResult CreateTransportRecord()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetReport(DateTime dateStart, DateTime dateEnd)
        {

        }

        [HttpPost]
        public async Task<IActionResult> RegisterTransportRecord(TransportRecordViewModel transportRecordViewModel)
        {
            var vehicle = _vehicleAppService.FindVehicleByLicensePlate(transportRecordViewModel.LicensePlate);

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
            await _vehicleAppService.AddTransportRecord(transportRecordViewModel);

            return View("CreateTransportRecord");
        }
    }
}
