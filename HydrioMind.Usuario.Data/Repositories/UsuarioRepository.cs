using HydrioMind.Usuario.Data.AppData;
using HydrioMind.Usuario.Domain.Entities;
using HydrioMind.Usuario.Domain.Interfaces;
using Microsoft.EntityFrameworkCore; // Certifique-se de que o namespace esteja presente para utilizar o FindAsync

namespace HydrioMind.Usuario.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public UsuarioEntity? Adicionar(UsuarioEntity usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return usuario; // Retorna a entidade adicionada
        }

        public UsuarioEntity? Editar(UsuarioEntity usuario)
        {
            var entity = _context.Usuario.Find(usuario.Id);
            
            if (entity != null)
            {
                entity.Nome = usuario.Nome;
                entity.Razao_Social = usuario.Razao_Social;
                entity.Email = usuario.Email;
                entity.CNPJ = usuario.CNPJ;
                
                _context.Usuario.Update(entity);
                _context.SaveChanges();
                return entity; // Retorna a entidade atualizada
            }

            return null;  // Caso a entidade não seja encontrada
        }

        public UsuarioEntity? ObterPorId(int id)
        {
            var entity = _context.Usuario.Find(id);
            return entity; // Retorna a entidade se encontrada, ou null se não for
        }

        public IEnumerable<UsuarioEntity> ObterTodos()
        {
            return _context.Usuario.ToList(); // Retorna todas as entidades
        }

        public UsuarioEntity? Remover(int id)
        {
            var entity = _context.Usuario.Find(id);
            
            if (entity != null)
            {
                _context.Usuario.Remove(entity);
                _context.SaveChanges();
                return entity; // Retorna a entidade removida
            }

            return null; // Caso a entidade não seja encontrada
        }
    }
}
