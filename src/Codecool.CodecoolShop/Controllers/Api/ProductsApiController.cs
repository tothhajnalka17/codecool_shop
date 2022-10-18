using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos.Implementations;
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

    }
}