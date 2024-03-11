using AutoMapper;
using Viacep.Application.Interfaces;
using Viacep.Application.Models;
using Viacep.Domain.Interfaces;
using Viacep.Infrastructure;

namespace Viacep.Application.Services
{
    public class ViacepAppService : IViacepAppService
    {
        private readonly IViacepService _viacepService;
        private readonly IMapper _mapper;

        public ViacepAppService(IMapper mapper, IViacepService viacepService)
        {
            _viacepService = viacepService;
            _mapper = mapper;
        }

        public async Task<ViacepResponse> GetCepAsync(string cep)
        {
            try
            {
                var viacep = await _viacepService.GetCepAsync(cep);
                var result = _mapper.Map<ViacepResponse>(viacep);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public string GetMessageFromCepResponse()
        {
            return _viacepService.GetMessageFromCepResponse();
        }
    }
}
