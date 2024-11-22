using Ecommerce.HydrioMind.Application.Services;
using Ecommerce.HydrioMind.Domain.Entities;
using Ecommerce.HydrioMind.Domain.Interfaces;
using Ecommerce.HydrioMind.Domain.Interfaces.Dtos;
using Moq;

namespace Ecommerce.HydrioMind.Tests
{
    public class UsuarioApplicationServiceTests
    {
        private readonly Mock<IUsuarioRepository> _repositoryMock;
        private readonly UsuarioApplicationService _usuarioService;

        public UsuarioApplicationServiceTests()
        {
            _repositoryMock = new Mock<IUsuarioRepository>();
            _usuarioService = new UsuarioApplicationService(_repositoryMock.Object);
        }

        [Fact]
        public void AdicionarUsuario_DeveRetornarUsuarioEntity_QuandoAdicionarComSucesso()
        {
            var usuarioDtoMock = new Mock<IUsuarioDto>();
            usuarioDtoMock.Setup(u => u.Nome).Returns("Murilo");
            usuarioDtoMock.Setup(u => u.SobreNome).Returns("Jose");
            usuarioDtoMock.Setup(u => u.Email).Returns("Murilo.jose@gmail.com");
            usuarioDtoMock.Setup(u => u.Idade).Returns(20);

            var usuarioEsperado = new UsuarioEntity { Nome = "Murilo", SobreNome = "Jose", Email = "murilo.jose@gmail.com", Idade = 20 };
            _repositoryMock.Setup(r => r.Adicionar(It.IsAny<UsuarioEntity>())).Returns(usuarioEsperado);

            var resultado = _usuarioService.AdicionarUsuario(usuarioDtoMock.Object);

            Assert.NotNull(resultado);
            Assert.Equal(usuarioEsperado.Nome, resultado.Nome);
            Assert.Equal(usuarioEsperado.SobreNome, resultado.SobreNome);
            Assert.Equal(usuarioEsperado.Email, resultado.Email);
            Assert.Equal(usuarioEsperado.Idade, resultado.Idade);
        }

        [Fact]
        public void EditarUsuario_DeveRetornarUsuarioEntity_QuandoEditarComSucesso()
        {
            var usuarioDtoMock = new Mock<IUsuarioDto>();
            usuarioDtoMock.Setup(u => u.Nome).Returns("Henry");
            usuarioDtoMock.Setup(u => u.SobreNome).Returns("Komatsu");
            usuarioDtoMock.Setup(u => u.Email).Returns("Henry.Komatsu@gmail.com");
            usuarioDtoMock.Setup(u => u.Idade).Returns(25);

            var usuarioEsperado = new UsuarioEntity { Id = 1, Nome = "Henry", SobreNome = "Komatsu", Email = "henry.komatsu@gmail.com", Idade = 21 };
            _repositoryMock.Setup(r => r.Editar(It.IsAny<UsuarioEntity>())).Returns(usuarioEsperado);

            var resultado = _usuarioService.EditarUsuario(1, usuarioDtoMock.Object);

            Assert.NotNull(resultado);
            Assert.Equal(usuarioEsperado.Id, resultado.Id);
            Assert.Equal(usuarioEsperado.Nome, resultado.Nome);
            Assert.Equal(usuarioEsperado.SobreNome, resultado.SobreNome);
            Assert.Equal(usuarioEsperado.Email, resultado.Email);
            Assert.Equal(usuarioEsperado.Idade, resultado.Idade);
        }

        [Fact]
        public void ObterUsuarioPorId_DeveRetornarUsuarioEntity_QuandoUsuarioExiste()
        {
            var usuarioEsperado = new UsuarioEntity { Id = 1, Nome = "Arthur", SobreNome = "Koga", Email = "arthur.koga@gmail.com", Idade = 18 };
            _repositoryMock.Setup(r => r.ObterPorId(1)).Returns(usuarioEsperado);

            var resultado = _usuarioService.ObterUsuarioPorId(1);

            Assert.NotNull(resultado);
            Assert.Equal(usuarioEsperado.Id, resultado.Id);
            Assert.Equal(usuarioEsperado.Nome, resultado.Nome);
            Assert.Equal(usuarioEsperado.SobreNome, resultado.SobreNome);
            Assert.Equal(usuarioEsperado.Email, resultado.Email);
            Assert.Equal(usuarioEsperado.Idade, resultado.Idade);
        }

        [Fact]
        public void ObterTodosUsuarios_DeveRetornarListaDeUsuarios_QuandoExistiremUsuarios()
        {
            var usuariosEsperados = new List<UsuarioEntity>
            {
                new UsuarioEntity { Id = 1, Nome = "Gabriel", SobreNome = "Martins", Email = "gabriel.martins@gmail.com", Idade = 31 },
                new UsuarioEntity { Id = 2, Nome = "Luiz", SobreNome = "Ferreira", Email = "luiz.ferreira@gmail.com", Idade = 21 }
            };
            _repositoryMock.Setup(r => r.ObterTodos()).Returns(usuariosEsperados);

            var resultado = _usuarioService.ObterTodosUsuarios();

            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Equal(usuariosEsperados.First().Nome, resultado.First().Nome);
        }

        [Fact]
        public void RemoverUsuario_DeveRetornarUsuarioEntity_QuandoRemoverComSucesso()
        {
            var usuarioEsperado = new UsuarioEntity { Id = 1, Nome = "Phelipe", SobreNome = "Souza", Email = "phelipe.souza@example.com", Idade = 40 };
            _repositoryMock.Setup(r => r.Remover(1)).Returns(usuarioEsperado);

            var resultado = _usuarioService.RemoverUsuario(1);

            Assert.NotNull(resultado);
            Assert.Equal(usuarioEsperado.Id, resultado.Id);
            Assert.Equal(usuarioEsperado.Nome, resultado.Nome);
            Assert.Equal(usuarioEsperado.SobreNome, resultado.SobreNome);
            Assert.Equal(usuarioEsperado.Email, resultado.Email);
            Assert.Equal(usuarioEsperado.Idade, resultado.Idade);
        }
    }
}
