using HydrioMind.Usuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HydrioMind.Usuario.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<UsuarioEntity> Usuario { get; set; }
    }
}
