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
        public ProductService _productService;

        public IProductDao MockProductDao = Substitute.For<IProductDao>();
        public IProductCategoryDao MockCategoryDao = Substitute.For<IProductCategoryDao>();

        public ProductCategory _productCategory0 = new ProductCategory();
        public ProductCategory _productCategory1 = new ProductCategory();
        public ProductCategory _productCategory2 = new ProductCategory();
        public ProductCategory _productCategory3 = new ProductCategory();

        public Product Product1 = new Product();
        public Product Product2 = new Product();
        public Product Product3 = new Product();
        public Product Product4 = new Product();
        public Product Product5 = new Product();

        public List<Product> MockProductList = new List<Product>();

        [SetUp]
        public void Setup()
        {
            _productService = new ProductService(MockProductDao, MockCategoryDao);
            
            _productCategory0.Id = 0;
            _productCategory1.Id = 1;
            _productCategory2.Id = 2;
            _productCategory3.Id = 3;

            Product1.ProductCategory = _productCategory0;
            Product2.ProductCategory = _productCategory0;
            Product3.ProductCategory = _productCategory1;
            Product4.ProductCategory = _productCategory1;
            Product5.ProductCategory = _productCategory2;

            MockCategoryDao.Get(0).Returns(_productCategory0);
            MockCategoryDao.Get(1).Returns(_productCategory1);
            MockCategoryDao.Get(2).Returns(_productCategory2);
            MockCategoryDao.Get(3).Returns(_productCategory3);

        }

        [Test]
        public void GetProductsForCategory_GetsValidId_ReturnsIEnumberableProducts()
        {
            // Arrange (add products that we know Get should bring back)
            var Test1Products = new List<Product> { Product1, Product2 };

            MockProductDao.GetBy(_productCategory0).Returns(Test1Products);

            // Act (ask method to bring back products)
            var TestProducts = _productService.GetProductsForCategory(0);

            // Assert (check if the two IEnumerable<Product>'s are the same)
            Assert.True(Test1Products.SequenceEqual(TestProducts));
        }

        [Test]
        public void GetProductsForCategory_GetsOutOfRangeId_BringsEmptyIEnumerable()
        {
            // Arrange
            

            // Act
            var TestProducts = _productService.GetProductsForCategory(11);

            // Assert
            Assert.True(TestProducts.Count() == 0);
        }

        [Test]
        public void GetProductsForCategory_GetsCategoryIdWithNoProducts_ReturnsEmptyIEnumberable()
        {
            // Arrange
            MockProductDao.GetBy(_productCategory3).Returns(new List<Product>());

            // Act
            var TestProducts = _productService.GetProductsForCategory(3);

            // Assert
            Assert.True(TestProducts.Count() == 0);
        }
    }
}