using HydrioMind.Usuario.Domain.Entities;
using HydrioMind.Usuario.Domain.Interfaces;
using HydrioMind.Usuario.Domain.Interfaces.Dtos;
using HydrioMind.Usuario.Domain;


namespace HydrioMind.Usuario.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioApplicationService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public UsuarioEntity? AdicionarUsuario(IUsuarioDto entity)
        {
            return _repository.Adicionar(new UsuarioEntity
            {
                Nome = entity.Nome,
                Razao_Social = entity.Razao_Social,
                Email = entity.Email,
                CNPJ = entity.CNPJ,
            });
        }

        public UsuarioEntity? EditarUsuario(int id, IUsuarioDto entity)
        {
            return _repository.Editar(new UsuarioEntity
            {
                Id = id,
                Nome = entity.Nome,
                Razao_Social = entity.Razao_Social,
                Email = entity.Email,
                CNPJ = entity.CNPJ,
            });
        }

        public UsuarioEntity? ObterUsuarioPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<UsuarioEntity>? ObterTodosUsuarios()
        {
            return _repository.ObterTodos();
        }

        public UsuarioEntity? RemoverUsuario(int id)
        {
            return _repository.Remover(id);
        }
    }
}
