using System.Net.Mime;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.DTO.Response;
using TravelXP.Prueba.Domain.Enums;
using TravelXP.Pueba.Application.Interfaces.Presenter;
using ErrorResponse = TravelXP.Prueba.Domain.DTO.Response.ErrorResponse;

namespace TravelXP.Prueba.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioPresenter _usuarioPresenter;

        public UsuarioController(IUsuarioPresenter usuarioPresenter)
        {
            _usuarioPresenter = usuarioPresenter;
        }

        // GET api/usuario
        [HttpGet]
        [Route("[controller]/[action]/{id}/{nombre}/{apellido}/{nombre_usuario}/{email}/{contrasena}/{foto_perfil}/{biografia}/{rol}")]
        [ProducesResponseType(typeof(List<IUsuarioPresenter>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Get(int id, string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol)
        {
            return Ok(await _usuarioPresenter.Get(id, nombre, apellido, nombre_usuario, email, contrasena,
                        foto_perfil, biografia, rol));
        }

        // POST api/usuario
        [HttpPost]
        [Route("[controller]/[action]/{nombre}/{apellido}/{nombre_usuario}/{email}/{contrasena}/{foto_perfil}/{biografia}/{rol}")]
        [ProducesResponseType(typeof(UsuarioResponse), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Post(string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol)
        {
            var result = await _usuarioPresenter.Post(nombre, apellido, nombre_usuario, email, contrasena, foto_perfil, biografia, rol);
            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { id = result.attributes.id }, result);
            }
            else
            {
                return BadRequest();
            }
        }
        // PATCH api/usuario/{id}
        [HttpPatch]
        [Route("[controller]/[action]/{nombre}/{apellido}/{nombre_usuario}/{email}/{contrasena}/{foto_perfil}/{biografia}")]
        [ProducesResponseType(typeof(UsuarioResponse), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Patch(string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, [FromBody] JsonPatchDocument<UsuarioPermisos> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            //var existingItem = _usuarioPresenter.Get(nombre, apellido, nombre_usuario, email, contrasena, foto_perfil, biografia);
            //if (existingItem == null)
            //{
            //    return NotFound();
            //}

            //patchDoc.ApplyTo(existingItem);

            var result = await _usuarioPresenter.Update(nombre, apellido, nombre_usuario, email, contrasena, foto_perfil, biografia);
            return result != null ? Ok(result) : BadRequest();
        }
        // DELETE
        [HttpDelete]
        [Route("[controller]/[action]/{id}")]
        [ProducesResponseType(typeof(void), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _usuarioPresenter.Delete(id);
            if (result != null) // Verifica si result no es nulo
            {
                return Ok(); // Si hay un resultado, se considera como éxito y se devuelve Ok()
            }
            else
            {
                return NotFound(); // Si no hay resultado, devuelve NotFound()
            }
        }
    }
}

