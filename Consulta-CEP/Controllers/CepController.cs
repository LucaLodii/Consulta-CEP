using Microsoft.AspNetCore.Mvc;
using ConsultaCep.Application.UseCases;

namespace Consulta_CEP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CepController : ControllerBase // Controller Layer (Web Layer)
    {
        private readonly ConsultarCepUseCase _consultarCepUseCase; // Use Case Layer (Application Layer)

        public CepController(ConsultarCepUseCase consultarCepUseCase) // Dependency Injection (Infrastructure Layer)
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
