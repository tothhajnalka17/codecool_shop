using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public interface IAuthenticationService
    {
        void AddUser(Registration registration);

        bool ValidateUser(Login login);
      
    }
}
