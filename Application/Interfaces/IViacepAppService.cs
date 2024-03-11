using Viacep.Application.Models;

namespace Viacep.Application.Interfaces
{
    public interface IViacepAppService
    {
        Task<ViacepResponse> GetCepAsync(string cep);
        string GetMessageFromCepResponse();
    }
}
