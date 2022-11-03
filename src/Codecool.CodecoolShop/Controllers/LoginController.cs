using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Net.Http;
using Codecool.CodecoolShop.Sql;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

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
                User user = Queries.GetUserByEmail(login.Email);
                
                var resp = new HttpResponseMessage();
                var cookie = new CookieHeaderValue("UserName", user.Name);
                
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
