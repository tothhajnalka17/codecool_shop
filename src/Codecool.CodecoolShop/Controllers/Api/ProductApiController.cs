using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit.IO;
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
        public IEnumerable<Product> FilteredProducts(Dictionary<string, List<string>> filters)
        {
            var productDaoMemory = ProductDaoMemory.GetInstance();
            List<string> categories = new();
            List<string> suppliers = new();
            IEnumerable<Product> categoryFilteredProducts = new List<Product>();
            IEnumerable<Product> supplierFilteredProducts = new List<Product>();

            if (filters.ContainsKey("category") )
            {
                categories = filters["category"];
                categoryFilteredProducts = productDaoMemory.GetByCategory(categories);
            } else { categoryFilteredProducts = productDaoMemory.GetAll();}

            if (filters.ContainsKey("supplier"))
            {
                suppliers = filters["supplier"];
                supplierFilteredProducts = productDaoMemory.GetBySupplier(suppliers);
            } else { supplierFilteredProducts = productDaoMemory.GetAll(); }

            return supplierFilteredProducts.Where(x => categoryFilteredProducts.Contains(x));


        }
    }
}
