using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Codecool.CodecoolShop.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ShowCheckOutCart")]
        public IActionResult ShowCheckOutCart(CheckOutModel checkOutModel)
        {
            //FirstName; LastName; Email; PhoneNumber;
            //BillingCountry; BillingCity; BillingZipCode; BillingAdress;
            //ShippingCountry; ShippingCity; ShippingZipCode; ShippingAdress;

            string firstName = checkOutModel.FirstName;
            string lastName = checkOutModel.LastName;
            string email = checkOutModel.Email;

            string phoneNumber = checkOutModel.PhoneNumber;
            string billingCountry = checkOutModel.BillingCountry;
            string billingCity = checkOutModel.BillingCity;
            string billingZipCode = checkOutModel.BillingZipCode;
            string billingAdress = checkOutModel.BillingAdress;

            string shippingCountry = checkOutModel.ShippingCountry;
            string shippingCity = checkOutModel.ShippingCity;
            string shippingZipCode = checkOutModel.ShippingZipCode;
            string shippingAdress = checkOutModel.ShippingAdress;

            Console.WriteLine($"{firstName} {lastName} {email} {phoneNumber}" +
                $" {billingCountry} {billingCity} {billingZipCode} {billingAdress}" +
                $"{shippingCountry} {shippingCity} {shippingZipCode} {shippingAdress}");

            //return RedirectToAction(actionName: "Index", controllerName: "Product");
            return View("ShowCheckOutCart", checkOutModel);
        }

    }
}
