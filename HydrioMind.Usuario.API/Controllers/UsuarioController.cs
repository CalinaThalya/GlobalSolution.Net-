using HydrioMind.Usuario.Application.Dtos;
using HydrioMind.Usuario.Domain.Entities;
using HydrioMind.Usuario.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HydrioMind.Usuario.API.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioApplicationService _applicationService;

        public UsuarioController(IUsuarioApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            var usuarios = _applicationService.ObterTodosUsuarios();

            if (usuarios != null && usuarios.Any())
                return Ok(usuarios);

            return NotFound("Nenhum usuário encontrado.");
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetPorId(int id)
        {
            var usuario = _applicationService.ObterUsuarioPorId(id);

            if (usuario != null)
                return Ok(usuario);

            return NotFound($"Usuário com ID {id} não encontrado.");
        }

        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        /// <param name="entity">Dados do usuário.</param>
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioEntity), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] UsuarioDto entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuario = _applicationService.AdicionarUsuario(entity);

return CreatedAtAction(nameof(GetPorId), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Edita um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <param name="entity">Novos dados do usuário.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UsuarioEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Put(int id, [FromBody] UsuarioDto entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuarioExistente = _applicationService.ObterUsuarioPorId(id);
            if (usuarioExistente == null)
                return NotFound($"Usuário com ID {id} não encontrado.");

            try
            {
                var usuarioAtualizado = _applicationService.EditarUsuario(id, entity);
                return Ok(usuarioAtualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        /// <summary>
        /// Remove um usuário.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UsuarioEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(int id)
        {
            var usuario = _applicationService.RemoverUsuario(id);

            if (usuario != null)
                return Ok(usuario);

            return NotFound($"Usuário com ID {id} não encontrado.");
        }
    }
}
