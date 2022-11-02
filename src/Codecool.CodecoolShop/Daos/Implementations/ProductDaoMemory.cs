using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class ProductDaoMemory : IProductDao
    {
        private List<Product> data = new List<Product>();
        private static ProductDaoMemory instance = null;

        private ProductDaoMemory()
        {
        }

        public static ProductDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductDaoMemory();
            }

            return instance;
        }

        public void Add(Product item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(this.Get(id));
        }

        public Product Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return data;
        }
        public Product GetByName(string name)
        {
            return data.Find(x => x.Name == name);
        }
        public IEnumerable<Product> GetBy(Supplier supplier)
        {
            return data.Where(x => x.Supplier.Id == supplier.Id);
        }

        public IEnumerable<Product> GetBy(ProductCategory productCategory)
        {
            return data.FindAll(x => x.ProductCategory.Id == productCategory.Id);
        }

        public IEnumerable<Product> GetByCategory(List<string> filters)
        {
            IEnumerable<Product> filteredProducts = new List<Product>();
            filteredProducts = data.Where(x => filters.Contains(x.ProductCategory.Department));    
            return filteredProducts;
        }
        
        public IEnumerable<Product> GetBySupplier(List<string> filters)
        {
            IEnumerable<Product> filteredProducts = new List<Product>();
            filteredProducts = data.Where(x => filters.Contains(x.Supplier.Name));    
            return filteredProducts;
        }

    }
}
