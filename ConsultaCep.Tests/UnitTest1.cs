using ConsultaCep.Application.UseCases;
using ConsultaCep.Domain.Entities;
using ConsultaCep.Domain.Interfaces;
using Moq;

namespace ConsultaCep.Tests
{
    public class ConsultarCepUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_ValidCep_ReturnsAddress()
        {
            // Arrange
            var mockCepService = new Mock<ICepService>();
            var expectedEndereco = new Endereco
            {
                Cep = "01310100",
                Logradouro = "Avenida Paulista",
                Localidade = "São Paulo",
                UF = "SP",
                Bairro = "Bela Vista",
                Complemento = ""
            };

            mockCepService
                .Setup(x => x.ConsultarCepAsync("01310100"))
                .ReturnsAsync(expectedEndereco);

            var useCase = new ConsultarCepUseCase(mockCepService.Object);

            // Act
            var result = await useCase.ExecuteAsync("01310100");

            // Assert
            Assert.Equal("01310100", result.Cep);
            Assert.Equal("Avenida Paulista", result.Logradouro);
            Assert.Equal("São Paulo", result.Localidade);
            Assert.Equal("SP", result.UF);
        }
    }
}