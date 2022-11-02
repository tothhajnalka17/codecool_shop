using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using System.Web;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private Guid Guid { get; set; }

        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }


        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance());
        }

        public IActionResult Index()
        {
            var products = ProductService.GetProductsForCategory(1);
            // Storing Value
            HttpContext.Session.SetString("ID", Guid.NewGuid().ToString());
            

            // Retrieving Value
            
            return View(products.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Viewer(int id)
        {
            var productDaoMemory = ProductDaoMemory.GetInstance();
            try
            {
                var product = productDaoMemory.Get(id);
                
                var related = productDaoMemory.GetBy(product.ProductCategory);
                related.ToList().Add(product);

                ViewBag.Id = id;
                return View(related.ToList());
            }
            catch (Exception)
            {
                return Error();
            }
        }
    }
}
