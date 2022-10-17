using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Codecool.CodecoolShop.Controllers.Api
{
    [Route("Products")]
    [ApiController]
    public class ProductApiController : Controller  
    {
        public List<Product> Products()
        {
            return JsonConvert.DeserializeObject<List<Product>>(Product);
            ;
        }
    }
}
