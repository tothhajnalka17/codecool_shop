using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace CodeCoolShop_Tests.MockClasses
{
    public class ProductDaoMock
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
    }
}
