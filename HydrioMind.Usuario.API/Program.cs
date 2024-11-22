using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os controladores
builder.Services.AddControllers();

// Adiciona a exploração de endpoints para o Swagger
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API HydrioMind",
        Version = "v1",  // Versão do Swagger
        Description = "API para consumir dados do MongoDB",
        Contact = new OpenApiContact
        {
            Name = "Seu Nome",
            Email = "seunome@dominio.com"
        }
    });
});

var app = builder.Build();

// Configuração do Swagger apenas para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Gera o arquivo Swagger
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API HydrioMind v1");  // Certifique-se de que o caminho para o arquivo JSON esteja correto
        options.RoutePrefix = string.Empty;  // Swagger UI na raiz
    });
}

// Configuração do HTTPS e autenticação
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();

// Iniciar o aplicativo
app.Run();
