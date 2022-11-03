using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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
        public void Update(Dictionary<string,int> dict)
        {
            var id = dict["id"];
            var quantity = dict["quantity"];

            var products = UserShoppingCart.GetAll();

            IDictionary<Product, int> countedProducts = products.GroupBy(x => x)
                 .ToDictionary(k => k.Key, v => v.Count());
            var countedProduct = countedProducts.Where(x => x.Key.Id == id).First();
            if (countedProduct.Value > quantity)
                UserShoppingCart.Remove(dict["id"]);
            else if (countedProduct.Value < quantity)
                UserShoppingCart.Add(countedProduct.Key);
           
        }
            
        [Route("Add")]
        public void Add(Dictionary<string, int> dict)
        {
            var productId = dict["id"];

            var product = AllProduct.GetAll().Where(myproduct => myproduct.Id == productId).First();
            UserShoppingCart.Add(product);
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
