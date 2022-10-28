using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
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
            
            return View();
        }

        public IActionResult GoToCheckout()
        {
            return Redirect("../Checkout");
        }
    }
}
