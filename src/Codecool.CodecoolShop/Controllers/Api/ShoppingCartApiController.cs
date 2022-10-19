using System.Collections;
using System.Collections.Generic;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers.Api
{
    [Route("ShoppingCartApi")]
    [ApiController]
    public class ShoppingCartApiController : Controller
    {
        public ShoppingCartDaoMemory UserShoppingCart { get; set; }

        public ShoppingCartApiController()
        {
            UserShoppingCart = ShoppingCartDaoMemory.GetInstance();
        }

        [Route("Get")]
        public IEnumerable<Product> GetAll()
        {
            var cart = UserShoppingCart.GetAll();
            return cart;
        }

        [Route("Add")]
        public IEnumerable<Product> Add(Product product)
        {
            UserShoppingCart.Add(product);
            var cart = UserShoppingCart.GetAll();
            return cart;
        }
    }
}
