using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace CodeCoolShop_Tests.MockClasses
{
    public class ProductCategoryDaoMock
    {
        public ProductCategoryDaoMock()
        {
        }

        public ProductCategory Get(int ProductId)
        {
            var productCategory = new ProductCategory();
            productCategory.Id = ProductId;
            return productCategory;
        }
    }
}
