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

            using (StreamReader r = new StreamReader(path))
            {
                var jsonString = await r.ReadToEndAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
                return products;
            }
        }

        [Route("Products")]
        public async Task<List<Product>> FilteredProducts()
        {
            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName
                , "Codecool.CodecoolShop\\Storage\\Products.json");

            List<Product> products = new List<Product>();
            using (StreamReader r = new StreamReader(path))
            {
                var jsonString = await r.ReadToEndAsync();
                products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            }

            // TODO read body and filter results accordingly
            Dictionary<string, List<string>> filters = new Dictionary<string, List<string>>();
            return products;
        }

    }
}
