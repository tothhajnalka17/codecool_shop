using System;
using System.Web.Helpers;
using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Codecool.CodecoolShop.Services
{
    public class RegistrationService : IRegistrationService
    {
        public string Errormessage { get; set; }    


        public bool IsEmailAvailable(Registration registration)
        {
            if(registration.Email == "asd@asd.asd")
            {
                Errormessage = "Email is already in use";
                return false;
            }
            return true;
        }

        public bool IsUsernameAvailable(Registration registration)
        {
            if(registration.Name == "asd")
            {
                Errormessage = "Username is already in use";
                return false;
            }
            return true;
        }

        public void AddUser(Registration registration)
        {
            if (registration.Name != null && registration.Email != null && registration.Password != null)
            {
                if (!IsUsernameAvailable(registration))
                {
                    Console.WriteLine("username taken");
                }
                else if (!IsEmailAvailable(registration))
                {
                    Console.WriteLine("email taken");

                }

                else
                {
                    Console.WriteLine(registration.Name);
                    Console.WriteLine(registration.Email);
                    var hashedPassword = Crypto.HashPassword(registration.Password);

                    //var verified = Crypto.VerifyHashedPassword(hash, "foo");
                    Console.WriteLine(hashedPassword);

                    //
                }
            
            }
            else
            {
                Console.WriteLine("Form is not filled");
            }
            

        }
    }
}
