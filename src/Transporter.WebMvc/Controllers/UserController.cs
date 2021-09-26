using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transporter.Administration.Application.Service;
using Transporter.Administration.Application.ViewModels;

namespace Transporter.WebMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        public IActionResult CreatePassenger()
        {
            return View();
        }

        public IActionResult CreateDriver()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserViewModel userViewModel)
        {
            var cpfInUse = _userAppService.FindPersonByCpf(userViewModel.CPF) != null;

            if (cpfInUse)
            {
                ViewBag.TheResult = false;
                ViewBag.MsgResult = "Cpf já cadastrado.";
                return View("CreateUser");
            }

            await _userAppService.AddUser(userViewModel);
            ViewBag.TheResult = true;

            return View("CreateUser");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPassenger(PassengerViewModel passengerViewModel)
        {
            var cpfInUse = _userAppService.FindPersonByCpf(passengerViewModel.CPF) != null;

            if (cpfInUse)
            {
                ViewBag.TheResult = false;
                ViewBag.MsgResult = "Cpf já cadastrado.";
                return View("CreatePassenger");
            }

            await _userAppService.AddPassenger(passengerViewModel);
            ViewBag.TheResult = true;

            return View("CreatePassenger");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDriver(DriverViewModel driverViewModel)
        {
            var cpfInUse = _userAppService.FindPersonByCpf(driverViewModel.CPF) != null;

            if (cpfInUse)
            {
                ViewBag.TheResult = false;
                ViewBag.MsgResult = "Cpf já cadastrado.";
                return View("CreateDriver");
            }

            await _userAppService.AddDriver(driverViewModel);
            ViewBag.TheResult = true;

            return View("CreateDriver");
        }
    }
}
