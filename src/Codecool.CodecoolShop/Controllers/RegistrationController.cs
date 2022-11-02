using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web.Helpers;

namespace Codecool.CodecoolShop.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]
        public IActionResult Register(Registration registration)
        {
            
            // Check if the username/email is already taken
            string ID = HttpContext.Session.GetString("ID");
            Console.WriteLine(ID);
            Console.WriteLine(registration.Name);
            Console.WriteLine(registration.Email);
            var hashedPassword = Crypto.HashPassword(registration.Password);

            //var verified = Crypto.VerifyHashedPassword(hash, "foo");
            Console.WriteLine(hashedPassword);
            

            return Redirect("/Product/Index");
        }
    }
}
