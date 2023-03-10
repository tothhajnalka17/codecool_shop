using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class PaymentModel
    {
       
        // card number, card holder, expiry date, and CVV code.
        [Display(Name = "Card number:")]

        [Required(ErrorMessage = "Card number is required")]
        [RegularExpression(@"^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$", ErrorMessage = "Please enter a valid card number")]
        public string CardNumber { get; set; }


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

        public PaymentModel(string cardNumber, string cardHolder, int expiryDateYear, int expiryDateMonth, string cVV)
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
