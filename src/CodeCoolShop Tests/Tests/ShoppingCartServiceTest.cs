using Codecool.CodecoolShop.Daos;

namespace CodeCoolShop_Tests
{
    public class ShoppingCartServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetCartByID_GetsString_ThrowsError()
        {
            Assert.Pass();
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