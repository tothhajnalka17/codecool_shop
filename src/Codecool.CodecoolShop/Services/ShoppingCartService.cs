using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;
using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Services
{
    public class ShoppingCartService
    {
        private readonly IShoppingCartDao ShoppingCartDao;

        public ShoppingCartService(IShoppingCartDao cartDao)
        {
            this.ShoppingCartDao = cartDao;
        }

        public IEnumerable<Product> GetCartById(int ShoppingCartId)
        {
            throw new NotImplementedException();
            //IEnumerable<Product> UserCart = this.ShoppingCartDao.Get(ShoppingCartId);
            //return UserCart;
        }
    }
}
