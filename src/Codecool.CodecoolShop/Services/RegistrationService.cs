using System;
using System.Web.Helpers;
using Codecool.CodecoolShop.Controllers;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Sql;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Codecool.CodecoolShop.Services
{
    public class RegistrationService : IRegistrationService
    {
        public string Errormessage { get; set; }    


        public bool IsEmailAvailable(Registration registration)
        {
            if (Queries.GetUserByEmail(registration.Email) != null)
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
                //TODO add feedback to user
                if (Queries.CheckIfUsernameExists(registration.Name))
                {
                    //Console.WriteLine("username taken");
                    throw new Exception("Username taken");
                  
                }
                else if (Queries.GetUserByEmail(registration.Email) != null)
                {
                    //Console.WriteLine("email taken");
                    throw new Exception("Email taken");

                }

                else
                {
                    Console.WriteLine(registration.Name);
                    Console.WriteLine(registration.Email);
                    registration.Password = Crypto.HashPassword(registration.Password);
                    //var verified = Crypto.VerifyHashedPassword(hash, "foo");
                    //Console.WriteLine(hashedPassword);

                    //
                    Queries.InsertUser(registration);
                }
            
            }
            else
            {
                Console.WriteLine("Form is not filled");
            }
            

        }
    }
}
