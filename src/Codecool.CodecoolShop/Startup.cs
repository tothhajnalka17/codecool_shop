using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.IO;
>>>>>>> codecool-shop-1-csharp-GergelyKamaras/development
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
<<<<<<< HEAD
=======
using Codecool.CodecoolShop.Services;
using Codecool.CodecoolShop.Settings;
>>>>>>> codecool-shop-1-csharp-GergelyKamaras/development
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
<<<<<<< HEAD
=======
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
>>>>>>> codecool-shop-1-csharp-GergelyKamaras/development

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
<<<<<<< HEAD
=======
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, Services.MailService>();
>>>>>>> codecool-shop-1-csharp-GergelyKamaras/development
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
<<<<<<< HEAD
=======

>>>>>>> codecool-shop-1-csharp-GergelyKamaras/development
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

<<<<<<< HEAD
        private void SetupInMemoryDatabases()
        {
            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();

            Supplier amazon = new Supplier{Name = "Amazon", Description = "Digital content and services"};
            supplierDataStore.Add(amazon);
            Supplier lenovo = new Supplier{Name = "Lenovo", Description = "Computers"};
            supplierDataStore.Add(lenovo);
            ProductCategory tablet = new ProductCategory {Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            productCategoryDataStore.Add(tablet);
            productDataStore.Add(new Product { Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = amazon });
            productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = tablet, Supplier = lenovo });
            productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });
=======
        private static void SetupInMemoryDatabases()
        {
            var productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();
            IShoppingCartDao shoppingCartStore = ShoppingCartDaoMemory.GetInstance();



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


>>>>>>> codecool-shop-1-csharp-GergelyKamaras/development
        }
    }
}
