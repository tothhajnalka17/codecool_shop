using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using NSubstitute;

namespace CodeCoolShop_Tests
{
    public class ShoppingCartServiceTests
    { 
        [SetUp]
        public void Setup()
        {
            //_cart = Substitute.For<ShoppingCartService>(Substitute.For<ProductCategory>());
        }

        [Test]
        public void GetCartByID_GetsString_ThrowsError()
        {
            // Arrange


            // Act
            //var product = _cart.GetCartById("1").Returns(NotImplementedException);

            // Assert

            //Assert.Throws<NotImplementedException>(_cart.GetCartById("1"));
        }

        [Test]
        public void GetCartByID_GetsIntOutOfRange_ThrowsError()
        {
            Assert.Pass();
        }

        [Test]
        public void GetCartByID_GetsIntInRange_ReturnsCart()
        {
            Assert.Pass();
        }
    }
}