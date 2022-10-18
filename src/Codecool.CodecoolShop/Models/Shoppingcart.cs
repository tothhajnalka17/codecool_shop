using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class ShoppingCart
    {
        public List<Product> ShoppingCartList { get; private set; }

        public double Total { get; set; }

        public readonly DateTime CreationTime;

        public ShoppingCart()
        {
            ShoppingCartList = new List<Product>();
            Total = 0;
            CreationTime = DateTime.Now;
        }

        void Add(Product product)
        {
            throw new NotImplementedException();
        }

        void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
