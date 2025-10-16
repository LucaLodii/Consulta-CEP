using ConsultaCep.Domain.Entities;

namespace ConsultaCep.Domain.Interfaces
{
    public interface ICepService
    {
        Task<Endereco> ConsultarCepAsync(string cep);
    }
}
