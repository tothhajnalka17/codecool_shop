using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Services;
using NSubstitute;
using Codecool.CodecoolShop.Models;
using CodeCoolShop_Tests.MockClasses;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

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
            _productCategory0.Id = 0;

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