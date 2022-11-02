using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product> ShoppingCartList { get; private set; }

        public decimal Total { get; private set; }

        public DateTime CreationTime { get; private set; }

        public DateTime LastModified { get; private set; }

        public ShoppingCart()
        {
            ShoppingCartList = new List<Product>();
            Total = 0;
        }

        public void Add(Product product)
        {
            if (ShoppingCartList == null)
            {
                CreationTime = DateTime.Now;

            }
            ShoppingCartList.Add(product);
            Total += product.DefaultPrice;
            LastModified = DateTime.Now;
        }

        public void Remove(int Id, bool RemoveAllProducts)
        {
            foreach (var item in ShoppingCartList)
            {
                if (item.Id == Id)
                {
                    ShoppingCartList.Remove(item);
                    Total -= item.DefaultPrice;
                    LastModified = DateTime.Now;

                    if (!RemoveAllProducts)
                    {
                        break;
                    }
                }
            }
        }

        public void EmptyCart()
        {
            ShoppingCartList.Clear();
            Total = 0;
            LastModified = DateTime.Now;
        }
    }
}
