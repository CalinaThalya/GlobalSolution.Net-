using HydrioMind.Usuario.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HydrioMind.Usuario.Data.AppData
{
    public class ApplicationDbContext : DbContext  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioEntity> Usuario { get; set; }
    }
}

