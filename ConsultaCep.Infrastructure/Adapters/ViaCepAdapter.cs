using ConsultaCep.Domain.Entities;
using ConsultaCep.Domain.Interfaces;
using ConsultaCep.Infrastructure.ExternalServices;
using System.Text.Json;

namespace ConsultaCep.Infrastructure.Adapters
{
    public class ViaCepAdapter : ICepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Endereco> ConsultarCepAsync(string cep)
        {
            try
            {
                // 1. Build the ViaCEP API URL
                var url = $"https://viacep.com.br/ws/{cep}/json/";

                // 2. Call the API
                var response = await _httpClient.GetAsync(url);

                // 3. Check if request was successful
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Erro ao consultar CEP: {response.StatusCode}");
                }

                // 4. Read and deserialize the JSON response
                var json = await response.Content.ReadAsStringAsync();
                var viaCepResponse = JsonSerializer.Deserialize<ViaCepResponse>(json);

                // 5. Check if CEP was found (ViaCEP returns error field when not found)
                if (viaCepResponse == null || string.IsNullOrEmpty(viaCepResponse.cep))
                {
                    throw new Exception("CEP não encontrado");
                }

                // 6. Convert ViaCepResponse to Endereco (domain model)
                var endereco = new Endereco
                {
                    Cep = viaCepResponse.cep ?? string.Empty,
                    Logradouro = viaCepResponse.logradouro ?? string.Empty,
                    Localidade = viaCepResponse.localidade ?? string.Empty,
                    UF = viaCepResponse.uf ?? string.Empty,
                    Bairro = viaCepResponse.bairro ?? string.Empty,
                    Complemento = viaCepResponse.complemento ?? string.Empty
                };

                return endereco;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao consultar CEP: {ex.Message}", ex);
            }
        }
    }
}
