using System.Collections.Generic;
using System;

namespace Codecool.CodecoolShop.Models
{
    public class Order
    {
        private List<Product> _orderList { get; set; }

        private DateTime _orderTime { get; set; }
        
        private string _firstName { get; set; }

        private string _lastName { get; set; }

        private ShippingMethod _shippingMethod { get; set; }

        private PaymentMethod _paymenthMethod { get; set; }

        private string _address { get; set; }

        public Order(List<Product> ShoppingCart, string firstName, string lastName, ShippingMethod shippingMethod,
            PaymentMethod paymentMethod, string address)
        {
            _orderList = ShoppingCart;
            _orderTime = DateTime.Now;
            _firstName = firstName;
            _lastName = lastName;
            _shippingMethod = shippingMethod;
            _paymenthMethod = paymentMethod;
            _address = address;
        }
    }
}
