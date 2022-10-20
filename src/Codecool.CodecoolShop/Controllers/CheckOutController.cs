using Codecool.CodecoolShop.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ShowCheckOutCart")]
        public IActionResult ShowCheckOutCart(CheckOutModel checkOutModel)
        {
            // TODO get from shopping cart
            

            //Console.WriteLine($"{firstName} {lastName} {email} {phoneNumber}" +
            //    $" {billingCountry} {billingCity} {billingZipCode} {billingAddress}" +
            //    $"{shippingCountry} {shippingCity} {shippingZipCode} {shippingAddress}");

            //return RedirectToAction(actionName: "Index", controllerName: "Product");
            Order order = new Order();
            order.ProductList = new List<Product>();

            order.FirstName = checkOutModel.FirstName;
            order.LastName = checkOutModel.LastName;
            order.Email = checkOutModel.Email;

            order.PhoneNumber = checkOutModel.PhoneNumber;
            order.BillingCountry = checkOutModel.BillingCountry;
            order.BillingCity = checkOutModel.BillingCity;
            order.BillingZipCode = checkOutModel.BillingZipCode;
            order.BillingAddress = checkOutModel.BillingAddress;

            order.ShippingCountry = checkOutModel.ShippingCountry;
            order.ShippingCity = checkOutModel.ShippingCity;
            order.ShippingZipCode = checkOutModel.ShippingZipCode;
            order.ShippingAddress = checkOutModel.ShippingAddress;

            Console.WriteLine(order);

            return View("ShowCheckOutCart", checkOutModel);
        }

        public IActionResult Payment()
        {
            return View();
        }

        //public IActionResult Payment(PaymentModel paymentModel)
        //{
        //    return View("Payment", paymentModel);
        //}

        

    }
}
