using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Codecool.CodecoolShop.Daos.Implementations;

namespace Codecool.CodecoolShop.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IMailService mailService;
        public IActionResult Index()
        {
            return View();
        }

        public CheckOutController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost]
        [ActionName("ShowCheckOutCart")]
        public IActionResult ShowCheckOutCart(CheckOutModel checkOutModel)
        {
            Order order = new Order();
            order.ProductList = ShoppingCartDaoMemory.GetInstance().GetAll().ToList();

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

            mailService.SendEmailAsync(order.Email, "Order Details", order.CreateHTMLString());

            ViewBag.OrderTotal = order.OrderTotal;
            return View("ShowCheckOutCart", checkOutModel);
        }

        public IActionResult Payment()
        {
            return View();
        }

        public IActionResult SuccessfullPayment()
        {
            return View();
        }
    }
}
