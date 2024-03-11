using Viacep.Domain.Entities;

namespace Viacep.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
