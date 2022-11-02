using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace CodeCoolShop_Tests.MockClasses
{
    public class ProductDaoMock : IProductDao
    {
        public ProductDaoMock()
        {
        }

        public Product Get(int ProductId)
        {
            var product = new Product();
            product.Id = ProductId;
            return product;
        }

        void IDao<Product>.Add(Product item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IDao<Product>.GetAll()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IProductDao.GetBy(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Product> IProductDao.GetBy(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }

        Product IDao<Product>.GetByName(string name)
        {
            throw new NotImplementedException();
        }

        void IDao<Product>.Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
