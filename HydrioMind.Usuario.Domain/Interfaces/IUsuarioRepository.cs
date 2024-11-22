using HydrioMind.Usuario.Domain.Entities;

namespace HydrioMind.Usuario.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
       UsuarioEntity? ObterPorId(int id);
        IEnumerable<UsuarioEntity>? ObterTodos();
       UsuarioEntity? Adicionar(UsuarioEntity Usuario);
        UsuarioEntity? Editar(UsuarioEntity usuario);
        UsuarioEntity? Remover(int id);
    }
}