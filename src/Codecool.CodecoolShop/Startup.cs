using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Codecool.CodecoolShop.Settings;
using Codecool.CodecoolShop.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace Codecool.CodecoolShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, Services.MailService>();
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
        private void SetupInMemoryDatabases()
        {
            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();
            IShoppingCartDao shoppingCartStore = ShoppingCartDaoMemory.GetInstance();

            string operatingMode = Configuration.GetSection("mode").Value;

            if (operatingMode == "sql")
            {
                AddDataFromDb(productDataStore, productCategoryDataStore, supplierDataStore);
            }
            else
            {
                AddDataFromJson(productDataStore, productCategoryDataStore, supplierDataStore);
            }
        }

        private void AddDataFromJson(IProductDao productDataStore, IProductCategoryDao productCategoryDataStore, ISupplierDao supplierDataStore)
        {
            var suppliersPath = Path.Combine(Directory.GetCurrentDirectory(), "Storage\\Supplier.json");
            var productCategoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Storage\\ProductCategory.json");
            var productPath = Path.Combine(Directory.GetCurrentDirectory(), "Storage\\Products.json");


            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>
                (new StreamReader(suppliersPath).ReadToEnd());
            LoadSuppliersToMemory(suppliers, supplierDataStore);
            

            var productCategories = JsonConvert.DeserializeObject<List<ProductCategory>>
                (new StreamReader(productCategoryPath).ReadToEnd());
            LoadProductCategoriesToMemory(productCategories, productCategoryDataStore);
            

            var products =
                JsonConvert.DeserializeObject<IEnumerable<Dictionary<string, string>>>(
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

        private void AddDataFromDb(IProductDao productDataStore, IProductCategoryDao productCategoryDataStore,
            ISupplierDao supplierDataStore)
        {
            var products = Queries.GetAllProducts();
            var categories = Queries.GetAllCategories();
            var suppliers = Queries.GetAllSuppliers();

            LoadSuppliersToMemory(suppliers, supplierDataStore);
            LoadProductCategoriesToMemory(categories, productCategoryDataStore);

            foreach (var product in products)
            {
                product.Supplier = suppliers.First(supplier => supplier.Id == product.Supplier_id);
                product.ProductCategory = categories.First(category => category.Id == product.Category_id);

                productDataStore.Add(product);
            }
        }

        private void LoadSuppliersToMemory(List<Supplier> suppliers, ISupplierDao supplierDataStore)
        {
            foreach (var supplier in suppliers)
            {
                supplierDataStore.Add(new Supplier
                {
                    Name = supplier.Name,
                    Description = supplier.Description
                });
            }
        }

        private void LoadProductCategoriesToMemory(List<ProductCategory> productCategories, IProductCategoryDao productCategoryDataStore)
        {
            foreach (var productCategory in productCategories)
            {
                productCategoryDataStore.Add(new ProductCategory
                {
                    Name = productCategory.Name,
                    Department = productCategory.Department,
                    Description = productCategory.Description
                });
            }
        }
    }
}
