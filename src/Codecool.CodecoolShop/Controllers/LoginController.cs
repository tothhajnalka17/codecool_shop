using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Codecool.CodecoolShop.Controllers
{
    public class LoginController : Controller
    {
        private IAuthenticationService _registrationService;
        public LoginController(IAuthenticationService registrationService)
        {
            _registrationService = registrationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(Login login)
        {
            if (_registrationService.ValidateUser(login))
            {
                return Redirect("/Login/LoginSuccessful");
            }
            return Redirect("/Login/LoginFailed");
        }

        public IActionResult LoginSuccessful()
        {
            return View();
        }

        public IActionResult LoginFailed()
        {
            return View();
        }
    }
}
