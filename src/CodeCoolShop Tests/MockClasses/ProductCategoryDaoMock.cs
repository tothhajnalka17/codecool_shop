using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace CodeCoolShop_Tests.MockClasses
{
    public class ProductCategoryDaoMock : IProductCategoryDao
    {
        public ProductCategoryDaoMock()
        {
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }

        public ProductCategory Get(int ProductId)
        {
            var productCategory = new ProductCategory();
            productCategory.Id = ProductId;
            return productCategory;
        }

        void IDao<ProductCategory>.Add(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ProductCategory> IDao<ProductCategory>.GetAll()
        {
            throw new NotImplementedException();
        }

        ProductCategory IDao<ProductCategory>.GetByName(string name)
        {
            throw new NotImplementedException();
        }

        void IDao<ProductCategory>.Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
