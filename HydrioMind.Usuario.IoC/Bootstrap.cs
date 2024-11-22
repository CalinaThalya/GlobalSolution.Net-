using HydrioMind.Usuario.Application.Services;
using HydrioMind.Usuario.Data.AppData;
using HydrioMind.Usuario.Data.Repositories;
using HydrioMind.Usuario.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HydrioMind.Usuario.IoC
{
    public class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(x => {
                x.UseOracle(configuration["ConnectionStrings:Oracle"]);
            });

            // Corrija o nome da interface e da classe aqui
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
        }
    }
}
