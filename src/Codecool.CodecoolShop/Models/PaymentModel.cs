using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class PaymentModel
    {
        // card number, card holder, expiry date, and CVV code.
        [Display(Name = "Card number:")]
        [CreditCard]
        [Required(ErrorMessage = "Card number is required")]
        public int CardNumber { get; set; }


        [Display(Name = "Card holder:")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "minimum 2 maximum 30 characters long.")]
        [Required(ErrorMessage = "Name is required")]
        public string CardHolder { get; set; }


        [Display(Name = "Expiration:")]
        [MinLength(2, ErrorMessage = "Please provide proper expiry year:")]
        [MaxLength(2, ErrorMessage = "Please provide proper expiry year:")]
        [Required(ErrorMessage = "Expiry year is required")]
        public int ExpiryDateYear { get; set; }


        [Display(Name = "/")]
        [MinLength(2, ErrorMessage = "Please provide proper month:")]
        [MaxLength(2, ErrorMessage = "Please provide proper month:")]
        [Required(ErrorMessage = "Expiry month is required")]
        public int ExpiryDateMonth { get; set; }


        [Display(Name = "CVV:")]
        [MinLength(3, ErrorMessage = "Please provide proper CVV number:")]
        [MaxLength(3, ErrorMessage = "Please provide proper CVV number:")]
        [Required(ErrorMessage = "CVV is required")]
        public string CVV { get; set; }

        public PaymentModel(int cardNumber, string cardHolder, int expiryDateYear, int expiryDateMonth, string cVV)
        {
            CardNumber = cardNumber;
            CardHolder = cardHolder;
            ExpiryDateYear = expiryDateYear;
            ExpiryDateMonth = expiryDateMonth;
            CVV = cVV;
        }

        public PaymentModel()
        {
            
        }
    }
}
