using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
            var cart = UserShoppingCart.GetAll();
            // Erre gondoltam Zoárd
            Dictionary<string, int> cartDictionary = cart.GroupBy(x => x.Name)
                .ToDictionary(k => k.Key, v => v.Count());
          
            return cartDictionary.ToJson();
        }

        [Route("Update")]
        public void Update(Dictionary<int,int> dict)
        {
            var products = AllProduct.GetAll().Where(x => dict.ContainsKey(x.Id));
            Dictionary<Product, int> countedProducts = products.GroupBy(x => x)
                .ToDictionary(k => k.Key, v => v.Count());
            if(countedProducts.Values.First() > dict.Values.First())
            {
                UserShoppingCart.Remove(dict.Keys.First());
            }
        }
            
        [Route("Add")]
        public void Add(Dictionary<string, int> dict)
        {
            var productId = dict["id"];

            var product = AllProduct.GetAll().Where(myproduct => myproduct.Id == productId).First();
            UserShoppingCart.Add(product);
        }

        [Route("RemoveOne")]
        public void RemoveOne(Dictionary<string, int> dict)
        {
            UserShoppingCart.Remove(dict["id"]);
        }

        [Route("RemoveAll")]
        public void RemoveAll(Dictionary<string, int> dict)
        {
            UserShoppingCart.RemoveAllById(dict["id"]);
        }

        [Route("RemoveCart")]
        public void RemoveAllFromCart()
        {
            UserShoppingCart.RemoveAll();
        }
    }
}
