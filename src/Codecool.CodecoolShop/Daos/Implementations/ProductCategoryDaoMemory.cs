using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.Linq;
>>>>>>> codecool-shop-1-csharp-GergelyKamaras/development
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    class ProductCategoryDaoMemory : IProductCategoryDao
    {
        private List<ProductCategory> data = new List<ProductCategory>();
        private static ProductCategoryDaoMemory instance = null;

        private ProductCategoryDaoMemory()
        {
        }

        public static ProductCategoryDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new ProductCategoryDaoMemory();
            }

            return instance;
        }

        public void Add(ProductCategory item)
        {
            item.Id = data.Count + 1;
            data.Add(item);
        }

        public void Remove(int id)
        {
            data.Remove(this.Get(id));
        }

        public ProductCategory Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

<<<<<<< HEAD
=======
        public ProductCategory GetByName(string name)
        {
            return data.Find(x => x.Name == name);
        }

>>>>>>> codecool-shop-1-csharp-GergelyKamaras/development
        public IEnumerable<ProductCategory> GetAll()
        {
            return data;
        }
    }
}
