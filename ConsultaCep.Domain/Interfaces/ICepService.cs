// Interface for the CepService (Task 3)
// This interface is used to define the contract for the CepService
// It is used to define the methods that the CepService must implement
// It is used to define the parameters that the CepService must implement
// It is used to define the return type that the CepService must implement
using ConsultaCep.Domain.Entities;

namespace ConsultaCep.Domain.Interfaces
{
    public interface ICepService
    {
        Task<Endereco> ConsultarCepAsync(string cep);
    }
}
