using Newtonsoft.Json.Serialization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class CheckOutModel
    {
        //Name, Email, Phone number
        //Billing Address (Country, City, Zipcode, Address)
        //Shipping Address (Country, City, Zipcode, Address)
        [StringLength(20, MinimumLength = 2)]
        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First name:")]
        public string FirstName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [Required(ErrorMessage = "Last name is required")]
        [DisplayName("Last name:")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required"), MinLength(1), DataType(DataType.EmailAddress), MaxLength(50), Display(Name = "Email:")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }


        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone number:")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }


        [DisplayName("Billing Country:")]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Billing country is required")]
        public string BillingCountry { get; set; }


        [DisplayName("Billing City:")]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Billing city is required")]
        public string BillingCity { get; set; }


        [DisplayName("Billing Zip Code:")]
        [StringLength(4, MinimumLength = 4)]

        [Required(ErrorMessage = "Billing zip code is required")]
        public string BillingZipCode { get; set; }


        [DisplayName("Billing Adress:")]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Billing adress is required")]
        public string BillingAddress { get; set; }



        [DisplayName("Shipping Country:")]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Shipping country is required")]
        public string ShippingCountry { get; set; }


        [DisplayName("Shipping City:")]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Shipping city is required")]
        public string ShippingCity { get; set; }


        [DisplayName("Shipping Zip Code:")]
        [StringLength(4, MinimumLength = 4)]

        [Required(ErrorMessage = "Shipping zip code is required")]
        public string ShippingZipCode { get; set; }


        [DisplayName("Shipping Adress:")]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Shipping adress is required")]
        public string ShippingAddress { get; set; }

        public CheckOutModel(string firstName, string lastName, string email, string phoneNumber, string billingCountry, string billingCity, string billingZipCode, string billingAddress, string shippingCountry, string shippingCity, string shippingZipCode, string shippingAddress)
        {
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
        }

        public CheckOutModel()
        {
        }
    }
}
