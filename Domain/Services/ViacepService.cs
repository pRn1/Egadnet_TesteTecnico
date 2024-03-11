using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using Viacep.Domain.Entities;
using Viacep.Domain.Interfaces;
using Viacep.Infrastructure;

namespace Viacep.Domain.Services
{
    public class ViacepService : IViacepService
    {
        private readonly HttpClient _httpClient;
        private readonly CepValidator _cepValidator;
        private IMemoryCache _cache;
        public string _message;

        public ViacepService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cepValidator = new CepValidator();
            _cache = cache;
        }

        public async Task<ViacepModel> GetCepAsync(string cep)
        {
            var result = await GetCepFromCacheOrSource(cep);
            return result;
        }

        public async Task<ViacepModel> GetCepFromCacheOrSource(string cep)
        {
            var key = $"Data_{cep}";
            if (_cache.TryGetValue(key, out ViacepModel cachedCep))
            {
                _message = "Dados obtidos do cache da aplicação";
                return cachedCep;
            }
            else
            {
                var cepResult = await GetCepFromSource(cep);
                _cache.Set(key, cepResult, TimeSpan.FromMinutes(5));

               _message = "Dados obtidos do local de origem: Viacep";
                return cepResult;
            }
        }

        public async Task<ViacepModel> GetCepFromSource(string cep)
        {
            if (_cepValidator.ValidateCepFormat(cep))
            {
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                if (!response.IsSuccessStatusCode)
                    throw new Exception("Falha ao consultar o serviço Viacep");

                var content = await response.Content.ReadAsStringAsync();
                var viacepResponse = JsonSerializer.Deserialize<ViacepModel>(content);
                return viacepResponse;
            }
            else
            {
                throw new ArgumentException($"Formato de CEP inválido. Favor fornecer apenas 8 dígitos numéricos. CEP: {cep}");
            }
        }

        public string GetMessageFromCepResponse()
        {
            return _message;
        }
    }
}
