namespace HydrioMind.Usuario.Domain.Interfaces.Dtos

{
    public interface IUsuarioDto
    {
        string Nome { get; set; }
        string Razao_Social { get; set; }
        string Email { get; set; }
        string CNPJ { get; set; }
    }
}

