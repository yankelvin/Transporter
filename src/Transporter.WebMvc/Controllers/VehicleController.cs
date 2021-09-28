using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transporter.Administration.Application.Service;
using Transporter.Transport.Application.Service;
using Transporter.Transport.Application.ViewModels;

namespace Transporter.WebMvc.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly ITransportAppService _vehicleAppService;
        private readonly IUserAppService _userAppService;

        public VehicleController(ITransportAppService vehicleAppService, IUserAppService userAppService)
        {
            _vehicleAppService = vehicleAppService;
            _userAppService = userAppService;
        }

        public IActionResult CreateVehicle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterVehicle(VehicleViewModel vehicleViewModel)
        {
            var licensePlateInUse = _vehicleAppService.FindVehicleByLicensePlate(vehicleViewModel.LicensePlate) != null;

            if (licensePlateInUse)
            {
                ViewBag.TheResult = false;
                ViewBag.MsgResult = "Placa do veículo já cadastrada.";
                return View("CreateVehicle");
            }

            var person = _userAppService.FindPersonByCpf(vehicleViewModel.CpfDriver);
            if (person == null)
            {
                ViewBag.TheResult = false;
                ViewBag.MsgResult = "Cpf não cadastrado.";
                return View("CreateVehicle");
            }

            var personIsDriver = _userAppService.FindDriverByPersonId(person.Id) != null;

            if (!personIsDriver)
            {
                ViewBag.TheResult = false;
                ViewBag.MsgResult = "O CPF informado não é de um motorista.";
                return View("CreateVehicle");
            }

            ViewBag.TheResult = true;
            await _vehicleAppService.AddVehicle(vehicleViewModel);

            return View("CreateVehicle");
        }
    }
}
