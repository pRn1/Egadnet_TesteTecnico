using Viacep.Domain.Entities;
using Viacep.Domain.Interfaces;

namespace Viacep.Domain.Services
{
    public class AuthService : IAuthService
    {
        public Task<User> AuthenticateAsync(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                var user = new User { Username = username, Password = "admin" };
                return Task.FromResult(user);
            }
            return null;
        }
    }
}
