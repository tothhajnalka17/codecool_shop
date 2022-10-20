using System.Collections.Generic;
using System;

namespace Codecool.CodecoolShop.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<Product> ProductList { get; set; }
        private DateTime OrderTime { get; set; }

        public decimal OrderTotal
        {
            get
            {
                return GetOrderTotal();
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string BillingCountry { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipCode { get; set; }
        public string BillingAddress { get; set; }

        public string ShippingCountry { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingZipCode { get; set; }
        public string ShippingAddress { get; set; }

        public ShippingMethod ShippingMethod { get; set; }

        public PaymentMethod PaymenthMethod { get; set; }

        public Order(Guid id, List<Product> productList, DateTime orderTime, string firstName, string lastName, string email, string phoneNumber, string billingCountry, string billingCity, string billingZipCode, string billingAddress, string shippingCountry, string shippingCity, string shippingZipCode, string shippingAddress, ShippingMethod shippingMethod, PaymentMethod paymenthMethod)
        {
            Id = new Guid();
            ProductList = productList;
            OrderTime = orderTime;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            BillingCountry = billingCountry;
            BillingCity = billingCity;
            BillingZipCode = billingZipCode;
            BillingAddress = billingAddress;
            ShippingCountry = shippingCountry;
            ShippingCity = shippingCity;
            ShippingZipCode = shippingZipCode;
            ShippingAddress = shippingAddress;
            ShippingMethod = ShippingMethod.PrivateDeliveryService;
            PaymenthMethod = PaymentMethod.Debitcard;
        }

        public Order()
        {
            Id = new Guid();
            ShippingMethod = ShippingMethod.PrivateDeliveryService;
            PaymenthMethod = PaymentMethod.Debitcard;
        }

        private decimal GetOrderTotal()
        {
            decimal sum = 0;
            foreach (var product in ProductList)
            {
                sum += product.DefaultPrice;
            }
            return sum;
        }

        public override string ToString()
        {
            string stringVersion = $"Dear {FirstName}! \n Thank you for your order!\n Order details:\n Order id: {Id}\n Ordered products: \n";
            foreach (Product product in ProductList)
            {
                stringVersion += $"\t{product.Name}\n";
            }

            stringVersion += $"Ordered at:{OrderTime}\n";

            return stringVersion;
        }


    }
}
