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
        public async Task<List<Product>> Products()
        {
            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName
                , "Codecool.CodecoolShop\\Storage\\Products.json");

            List<Product> products = new List<Product>();
            using (StreamReader r = new StreamReader(path))
            {
                var jsonString = await r.ReadToEndAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            }
            return products;
        }
        [Route("Filter")]
        public async Task<List<Product>> FilteredProducts(Dictionary<string, List<string>> filters)
        {
            foreach (var filter in filters)
            {
                Console.WriteLine(filter.Key);
                foreach (var item in filter.Value)
                {
                    Console.WriteLine(item);
                }
            }
            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName
                , "Codecool.CodecoolShop\\Storage\\Products.json");

            using (StreamReader r = new StreamReader(path))
            {
                var jsonString = await r.ReadToEndAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
                return products;
            }
        }
    }
}
