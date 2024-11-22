using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HydrioMind.Usuario.Domain.Entities
{
    public class UsuarioEntity
    {
        [Key]
        public int Id { get; set; }
public string Nome { get; set; }
         public string Razao_Social { get; set; }
    public string Email { get; set; }
    public string CNPJ { get; set; }
    }
}
