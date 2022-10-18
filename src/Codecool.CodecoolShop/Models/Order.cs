using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class Order
    {
        private List<Product> _orderList { get; set; }

        public Order(List<Product> ShoppingCart)
        {
            _orderList = ShoppingCart;
        }
    }
}
