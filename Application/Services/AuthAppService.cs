using AutoMapper;
using Viacep.Application.Interfaces;
using Viacep.Application.Models;
using Viacep.Domain.Interfaces;

namespace Viacep.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthAppService(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<UserCredentials> AuthenticateAsync(string username, string password)
        {
            try
            {
                var authUser = await _authService.AuthenticateAsync(username, password);
                var result = _mapper.Map<UserCredentials>(authUser);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
