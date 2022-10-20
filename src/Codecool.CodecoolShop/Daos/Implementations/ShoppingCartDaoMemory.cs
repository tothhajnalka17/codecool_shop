using Codecool.CodecoolShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class ShoppingCartDaoMemory : IShoppingCartDao
    {
        private List<Product> _cart = new List<Product>();
        private static ShoppingCartDaoMemory instance = null;

        private ShoppingCartDaoMemory()
        {
        }

        public static ShoppingCartDaoMemory GetInstance()
        {
            if (instance == null)
            {
                instance = new ShoppingCartDaoMemory();
            }

            return instance;
        }

        public void Add(Product product)
        {
            _cart.Add(product);
        }

        public void Remove(int id)
        {
            var item = _cart.Where(x => x.Id == id).FirstOrDefault();
            _cart.Remove(item);
        }

        public void RemoveAll()
        {
            _cart.Clear();
        }

        public void RemoveAllById(int id)
        {
            var items = _cart.Where(x => x.Id == id).ToList();
            foreach (var item in items)
            {
                _cart.Remove(item);
            }
        }

        public Product Get(int id)
        {
            return _cart.Find(x => x.Id == id);
        }

        public Product GetByName(string name)
        {
            return _cart.Find(x => x.Name == name);
        }

        public IEnumerable<Product> GetAll()
        {
            return _cart;
        }


    }
}
