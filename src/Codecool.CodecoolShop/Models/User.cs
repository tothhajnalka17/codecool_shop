using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }

        public List<Order> OrderList { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
    }
}
