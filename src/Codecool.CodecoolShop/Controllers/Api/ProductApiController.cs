using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Codecool.CodecoolShop.Controllers.Api
{
    [Route("Products")]
    [ApiController]
    public class ProductApiController : Controller  
    {
        public IEnumerable<Product> GetProducts()
        {
            var productDaoMemory = ProductDaoMemory.GetInstance();
            var products = productDaoMemory.GetAll();

            return products;
        }

        [Route("Filter")]
        public async Task<List<Product>> FilteredProducts(Dictionary<string, List<string>> filters)
        {
            var productDaoMemory = ProductDaoMemory.GetInstance();
            var products = productDaoMemory.GetAll();
            // TODO actually filter the data
            foreach (var filter in filters)
            {
                Console.WriteLine(filter.Key);
                foreach (var item in filter.Value)
                {
                    Console.WriteLine(item);
                }
            }
            
            return products;
        }
    }
}
