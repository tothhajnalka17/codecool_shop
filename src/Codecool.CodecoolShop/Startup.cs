using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Codecool.CodecoolShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            SetupInMemoryDatabases();
        }

        private static void SetupInMemoryDatabases()
        {
            var productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();

            var suppliersPath = Path.Combine(Directory.GetCurrentDirectory(), "Storage\\Supplier.json");
            var productCategoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Storage\\ProductCategory.json");
            var productPath = Path.Combine(Directory.GetCurrentDirectory(), "Storage\\Products.json");

       
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>
                (new StreamReader(suppliersPath).ReadToEnd());

            foreach (var supplier in suppliers)
            {
                supplierDataStore.Add(new Supplier
                {
                    Name = supplier.Name,
                    Description = supplier.Description
                });
            }

            var productCategories = JsonConvert.DeserializeObject<List<ProductCategory>>
                (new StreamReader(productCategoryPath).ReadToEnd());

            foreach (var productCategory in productCategories)
            {
                productCategoryDataStore.Add(new ProductCategory
                {
                    Name = productCategory.Name,
                    Department = productCategory.Department,
                    Description = productCategory.Description
                });
            }

            var products =
                JsonConvert.DeserializeObject<IEnumerable<Dictionary<string,string>>>(
                    new StreamReader(productPath).ReadToEnd());
            foreach (var product in products)
            {
               
                productDataStore.Add(new Product
                {
                    Name = product["name"],
                    DefaultPrice = Convert.ToDecimal(product["defaultPrice"]),
                    Currency = product["currency"],
                    Description = product["description"],
                    ProductCategory = productCategoryDataStore.GetByName(product["productCategory"]),
                    Supplier = supplierDataStore.GetByName(product["supplier"])

                });
            }


        }
    }
}
