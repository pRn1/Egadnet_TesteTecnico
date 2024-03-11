using System.Net.Http.Json;
using Viacep.Domain.Entities;
using Viacep.Domain.Interfaces;

namespace Viacep.Domain.Services
{
    public class AuthService : IAuthService
    {
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return new User { Username = username, Password = "admin" };
            }
            return null;
        }
    }
}
