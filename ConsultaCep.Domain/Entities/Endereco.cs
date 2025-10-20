namespace ConsultaCep.Domain.Entities
{
    public class Endereco   // Main entity of the domain, (Task 2)
    {
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Localidade { get; set; } // Its the same as Cidade
        public string? UF { get; set; }
        public string? Bairro { get; set; }
        public string? Complemento { get; set; }
    }
}