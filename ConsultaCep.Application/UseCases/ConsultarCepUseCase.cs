using ConsultaCep.Domain.Entities;
using ConsultaCep.Domain.Interfaces;
using ConsultaCep.Application.DTOs;

namespace ConsultaCep.Application.UseCases
{
    public class ConsultarCepUseCase
    {
        private readonly ICepService _cepService;

        public ConsultarCepUseCase(ICepService cepService) // Dependency Injection 
        {
            _cepService = cepService;
        }

        public async Task<ConsultarCepResponse> ExecuteAsync(string cep) // Business Logic 
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8) // Validation 
            {
                throw new ArgumentException("CEP inválido");
            }
            var endereco = await _cepService.ConsultarCepAsync(cep); // fetch the data from the external service (ViaCEP API)
            var response = new ConsultarCepResponse // Convert the data to the response object
            {
                Cep = endereco.Cep,
                Logradouro = endereco.Logradouro,
                Localidade = endereco.Localidade,
                UF = endereco.UF,
                Bairro = endereco.Bairro,
                Complemento = endereco.Complemento
            };
            return response; // Return the response as a Task<ConsultarCepResponse> 
        }
    }
}
