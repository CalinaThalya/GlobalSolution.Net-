using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using HydrioMind.Usuario.Application;  
using HydrioMind.Usuario.Domain.Interfaces;
using HydrioMind.Usuario.Application.Services;
using HydrioMind.Usuario.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using HydrioMind.Usuario.Data.AppData;  // Importar o namespace do ApplicationContext

var builder = WebApplication.CreateBuilder(args);

// Registra o contexto do banco de dados (ApplicationContext)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));

// Adiciona os controladores
builder.Services.AddControllers();

// Registra o serviço IUsuarioApplicationService com a implementação correspondente
builder.Services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();

// Registra o repositório IUsuarioRepository com a implementação correspondente
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Adiciona a exploração de endpoints para o Swagger
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API HydrioMind",
        Version = "v1", 
        Description = "API para consumir dados do MongoDB",  // Ajuste conforme sua necessidade
        Contact = new OpenApiContact
        {
            Name = "Calina",
            Email = "calinathalya77@gmail.com"
        }
    });
});

var app = builder.Build();

// Configuração do Swagger apenas para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API HydrioMind v1");
        options.RoutePrefix = string.Empty;  
    });
}

// Configuração do HTTPS e autenticação
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();

// Iniciar o aplicativo
app.Run();
