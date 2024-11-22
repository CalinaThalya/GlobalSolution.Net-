using HydrioMind.Usuario.Domain.Entities;
using HydrioMind.Usuario.Domain.Interfaces.Dtos;

namespace HydrioMind.Usuario.Domain.Interfaces
{
    public interface IUsuarioApplicationService
    {
        IEnumerable<UsuarioEntity> ObterTodosUsuarios();
       UsuarioEntity ObterUsuarioPorId(int id);
       UsuarioEntity AdicionarUsuario(IUsuarioDto entity);
     UsuarioEntity EditarUsuario(int id, IUsuarioDto entity);
     UsuarioEntity RemoverUsuario(int id);
    }
}
    