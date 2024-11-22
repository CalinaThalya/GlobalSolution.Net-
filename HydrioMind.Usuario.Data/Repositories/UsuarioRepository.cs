using HydrioMind.Usuario.Data.AppData;
using HydrioMind.Usuario.Domain.Entities;
using HydrioMind.Usuario.Domain.Interfaces;

namespace HydrioMind.Usuario.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;

        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UsuarioEntity? Adicionar(UsuarioEntity usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public UsuarioEntity? Editar(UsuarioEntity usuario)
        {
            var entity = _context.Usuario.Find(usuario.Id);
            
            if (entity is not null)
            {
                entity.Nome = usuario.Nome;
                entity.Razao_Social = usuario.Razao_Social;
                entity.Email = usuario.Email;
                entity.CNPJ = usuario.CNPJ;
                
                _context.Usuario.Update(entity);
                _context.SaveChanges();
            }
            return null;    
        }

        public UsuarioEntity? ObterPorId(int id)
        {
            var entity = _context.Usuario.Find(id);
            
            if (entity is not null)
            {
                return entity;
            }
            return null;   
        }

        public IEnumerable<UsuarioEntity> ObterTodos()
        {
            var entity = _context.Usuario.ToList();

            return entity;
        }

        public UsuarioEntity? Remover(int id)
        {
            var entity = _context.Usuario.Find(id);
            
            if (entity is not null)
            {
                _context.Usuario.Remove(entity);
                _context.SaveChanges();

                return entity;
            }
            return null;  
        }
    }
}
