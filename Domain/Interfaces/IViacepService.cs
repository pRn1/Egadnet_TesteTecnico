using Viacep.Domain.Entities;

namespace Viacep.Domain.Interfaces
{
    public interface IViacepService
    {
        Task<ViacepModel> GetCepAsync(string cep);
        string GetMessageFromCepResponse();
    }
}
