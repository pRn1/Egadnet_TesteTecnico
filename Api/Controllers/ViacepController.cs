using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Viacep.Application.Interfaces;

namespace ViacepEgadnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViacepController : Controller
    {
        private IViacepAppService _viacepAppService;
        private readonly IMemoryCache _cache;

        public ViacepController(IViacepAppService viacepAppService, IMemoryCache cache)
        {
            _viacepAppService = viacepAppService;
            _cache = cache;
        }

        [Authorize(Policy = "Bearer")]
        [HttpGet("{cep}")]
        public async Task<IActionResult> GetCep(string cep)
        {
            try
            {
                var cepResponse = await _viacepAppService.GetCepAsync(cep);
                var messageResponse = _viacepAppService.GetMessageFromCepResponse();
                var response = new { Mensagem = messageResponse, Dados = cepResponse };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
