using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Codecool.CodecoolShop.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required"), MinLength(1), DataType(DataType.EmailAddress), MaxLength(50), Display(Name = "Email:")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [DisplayName("Password: ")]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Login()
        {

        }
    }

}
