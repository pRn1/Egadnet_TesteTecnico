using Viacep.Application.Models;

namespace Viacep.Application.Interfaces
{
    public interface IAuthAppService
    {
        public Task<UserCredentials> AuthenticateAsync(string username, string password);
    }
}
