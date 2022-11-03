using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Codecool.CodecoolShop.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(Login login)
        {
            Console.WriteLine(login.Email);
            Console.WriteLine(login.Password);
            
            return Redirect("/Login/Index");
        }

    }
}
