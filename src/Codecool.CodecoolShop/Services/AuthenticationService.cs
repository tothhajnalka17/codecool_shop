using System;
using System.Web.Helpers;
using Codecool.CodecoolShop.Controllers;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Sql;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Codecool.CodecoolShop.Services
{
    public class AuthenticationService : IAuthenticationService
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
                    throw new Exception("Username taken"); 
                }
                else if (Queries.GetUserByEmail(registration.Email) != null)
                {
                    throw new Exception("Email taken");
                }
                else
                {
                    registration.Password = Crypto.HashPassword(registration.Password);
                    Queries.InsertUser(registration);
                }
            }
            else
            {
                Console.WriteLine("Form is not filled");
            }
        }
        
        public bool ValidateUser(Login login)
        {
            User user = Queries.GetUserByEmail(login.Email);
            if (user != null)
            {
                var verified = Crypto.VerifyHashedPassword(user.Password, login.Password);
                return verified;
            }
            return false;
        }
    }
}
