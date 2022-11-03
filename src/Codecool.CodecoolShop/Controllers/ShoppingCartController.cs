using Codecool.CodecoolShop.Controllers.Api;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ShoppingCartDaoMemory UserShoppingCart { get; set; }


        public ShoppingCartController()
        {
            UserShoppingCart = ShoppingCartDaoMemory.GetInstance();
        }

        [Route("ShoppingCart")]
        public IActionResult ShoppingCart()
        { 
            
            var products = UserShoppingCart.GetAll();
            IDictionary<Product, int> countedProducts = products.GroupBy(x => x)
                .ToDictionary(k => k.Key, v => v.Count());
            return View(countedProducts);
        }

        public IActionResult GoToCheckout()
        {
            return Redirect("../Checkout");
        }
    }
}
