using ConsultaCep.Domain.Entities;
using ConsultaCep.Domain.Interfaces;
using ConsultaCep.Application.DTOs;

namespace ConsultaCep.Application.UseCases
{
    public class ConsultarCepUseCase
    {
        private readonly ICepService _cepService;

        public ConsultarCepUseCase(ICepService cepService)
        {
            _cepService = cepService;
        }

        public async Task<ConsultarCepResponse> ExecuteAsync(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8)
            {
                throw new ArgumentException("CEP inválido");
            }
            var endereco = await _cepService.ConsultarCepAsync(cep);
            var response = new ConsultarCepResponse
            {
                Cep = endereco.Cep,
                Logradouro = endereco.Logradouro,
                Localidade = endereco.Localidade,
                UF = endereco.UF,
                Bairro = endereco.Bairro,
                Complemento = endereco.Complemento
            };
            return response;
        }
    }
}
