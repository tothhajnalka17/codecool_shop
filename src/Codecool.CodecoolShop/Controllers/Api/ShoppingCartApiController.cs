using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace Codecool.CodecoolShop.Controllers.Api
{
    [Route("ShoppingCartApi")]
    [ApiController]
    public class ShoppingCartApiController : Controller
    {
        public ShoppingCartDaoMemory UserShoppingCart { get; set; }
        public ProductDaoMemory AllProduct { get; set; }

        public ShoppingCartApiController()
        {
            UserShoppingCart = ShoppingCartDaoMemory.GetInstance();
            AllProduct = ProductDaoMemory.GetInstance();
        }

        [Route("Get")]
        public string GetAll()
        {
            var cart = UserShoppingCart.GetAll().ToList();
            Dictionary<string, int> cartDictionary = new Dictionary<string, int>();

            for (int i = 0; i < cart.Count(); i++)
            {
                if (cartDictionary.ContainsKey(cart[i].ToJson()))
                {
                    cartDictionary[cart[i].ToJson()] += 1;
                }
                else
                {
                    cartDictionary.Add(cart[i].ToJson(), 1);
                }
            }

            return cartDictionary.ToJson();
        }

        [Route("Add")]
        public void Add(Dictionary<string, int> dict)
        {
            var productId = dict["id"];

            var product = AllProduct.GetAll().Where(myproduct => myproduct.Id == productId).First();
            UserShoppingCart.Add(product);
        }

        [Route("RemoveOne")]
        public void Remove(int id)
        {
            UserShoppingCart.Remove(id);
        }

        [Route("RemoveAll")]
        public void RemoveAll(int id)
        {
            UserShoppingCart.RemoveAllById(id);
        }

        [Route("RemoveCart")]
        public void RemoveAllFromCart()
        {
            UserShoppingCart.RemoveAll();
        }
    }
}
