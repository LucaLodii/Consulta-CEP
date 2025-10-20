using Microsoft.AspNetCore.Mvc;
using ConsultaCep.Application.UseCases;

namespace Consulta_CEP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ConsultarCepUseCase _consultarCepUseCase;

        public CepController(ConsultarCepUseCase consultarCepUseCase)
        {
            _consultarCepUseCase = consultarCepUseCase;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> Get(string cep)
        {
            var result = await _consultarCepUseCase.ExecuteAsync(cep);
            return Ok(result);
        }
    }
}
