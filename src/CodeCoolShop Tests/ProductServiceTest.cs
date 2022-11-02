using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Daos;

namespace CodeCoolShop_Tests
{
    public class ProductServiceTests
    {
        [SetUp]
        public void Setup()
        {


        }

        [Test]
        public void GetProductCategory_GetsValidId_ReturnsCategory()
        {
            // arrange

            // act

            // assert
            Assert.Pass();
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