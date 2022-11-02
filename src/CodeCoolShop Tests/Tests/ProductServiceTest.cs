using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Services;
using NSubstitute;
using Codecool.CodecoolShop.Models;
using CodeCoolShop_Tests.MockClasses;

namespace CodeCoolShop_Tests
{
    public class ProductServiceTests
    {
        ProductService _productService;

        ProductDaoMock _productDaoMock = new ProductDaoMock();
        ProductCategoryDaoMock _productCategoryDaoMock = new ProductCategoryDaoMock();
        ProductCategory _productCategory0 = Substitute.For<ProductCategory>();

        [SetUp]
        public void Setup()
        {
            _productService = new ProductService(_productDaoMock, _productCategoryDaoMock);
            _productCategoryDaoMock.Get(0).Returns(_productCategory0);

        }

    [Test]
        public void GetProductCategory_GetsValidId_ReturnsCategory()
        {
            // arrange


            // act
            ProductCategory TestCategory = _productService.GetProductCategory(0);


            // assert
            Assert.Equals(TestCategory, _productCategory0);
        }

        [Test]
        public void GetProductCategory_GetsOutOfRangeId_ThrowError()
        {
            Assert.Pass();
        }

        [Test]
        public void GetProductCategory_GetsString_ThrowError()
        {
            Assert.Pass();
        }

        [Test]
        public void GetProductsForCategory_GetsValidId_ReturnsIEnumberableProducts()
        {
            Assert.Pass();
        }

        [Test]
        public void GetProductsForCategory_GetsOutOfRangeId_ThrowsError()
        {
            Assert.Pass();
        }

        [Test]
        public void GetProductsForCategory_GetsString_ReturnsIEnumberableProducts()
        {
            Assert.Pass();
        }
    }
}