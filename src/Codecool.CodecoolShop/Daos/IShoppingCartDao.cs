using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos
{
    public interface IShoppingCartDao : IDao<Product>
    {
        void RemoveAll();

        void RemoveAllById(int id);
    }
}
