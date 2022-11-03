using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Helpers;

namespace Codecool.CodecoolShop.Controllers
{
    public class RegistrationController : Controller
    {
        private IAuthenticationService _authenticationService;
        public RegistrationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]
        public IActionResult Register(Registration registration)
        {
            try
            {
                _authenticationService.AddUser(registration);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Redirect("/Registration/RegistrationFailed");
            }
            return Redirect("/Registration/RegistrationSuccessful");
        }

        public IActionResult RegistrationFailed()
        {
            return View();
        }

        public IActionResult RegistrationSuccessful()
        {
            return View();
        }
        
    }
}
