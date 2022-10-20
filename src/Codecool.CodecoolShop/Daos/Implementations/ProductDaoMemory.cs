using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Models;
using Newtonsoft.Json.Linq;

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

        public IEnumerable<Product> GetBy(Supplier supplier)
        {
            return data.Where(x => x.Supplier.Id == supplier.Id);
        }

        public IEnumerable<Product> GetBy(ProductCategory productCategory)
        {
            return data.Where(x => x.ProductCategory.Id == productCategory.Id);
        }

        public IEnumerable<Product> GetByCategory(Dictionary<string, List<string>> filters)
        {
            IEnumerable<Product> filteredProducts = new List<Product>();

            if (filters.Keys.Contains("category"))
            {
                foreach (var categoryValues in filters["category"])
                    filteredProducts = filteredProducts.Concat(data.Where(x => categoryValues.Contains(x.ProductCategory.Department)));
                
                if (filters.Keys.Contains("supplier"))
                {
                    IEnumerable<Product> supplierSelect = new List<Product>();
                    foreach (var supplierValues in filters["supplier"])
                        supplierSelect = supplierSelect.Concat(filteredProducts.Where(x => supplierValues.Contains(x.Supplier.Name)));

                    return supplierSelect;

                } return filteredProducts;
            }
            else if (!filters.Keys.Contains("category"))
            {
                foreach (var supplierValues in filters["supplier"])
                    filteredProducts = filteredProducts.Concat(data.Where(x => supplierValues.Contains(x.Supplier.Name)));

                return filteredProducts;
            }
            return GetAll();
        }
    }
}
