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
    public class PublicacionesController : ControllerBase
    {
        private readonly IPublicacionesPresenter _publicacionesPresenter;

        public PublicacionesController(IPublicacionesPresenter publicacionesPresenter)
        {
            _publicacionesPresenter = publicacionesPresenter;
        }

        // GET api/publicaciones
        [HttpGet]
        [Route("[controller]/[action]/{publicacion_id}/{usuario_id}/{fecha}/{imagen}/{descripcion}/{tipo_publicacion}/{ubicacion}")]
        [ProducesResponseType(typeof(List<IPublicacionesPresenter>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Get(int publicacion_id, int usuario_id, DateTime fecha,
            string imagen, string descripcion, string tipo_publicacion, string ubicacion)
        {
            return Ok(await _publicacionesPresenter.Get(publicacion_id, usuario_id, fecha, imagen,
                descripcion, tipo_publicacion, ubicacion));
        }

        /// POST api/publicaciones
        [HttpPost]
        [Route("[controller]/[action]/{descripcion}/{imagen}/{ubicacion}")]
        [ProducesResponseType(typeof(PublicacionesResponse), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Post(string descripcion, string imagen, string ubicacion)
        {
            var result = await _publicacionesPresenter.Post(descripcion, imagen, ubicacion);
            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { id = result.attributes.publicacion_id }, result);
            }
            else
            {
                return BadRequest();
            }
        }
        // PATCH api/publicaciones/{id}
        [HttpPatch]
        [Route("[controller]/[action]/{descripcion}/{ubicacion}/{imagen}")]
        [ProducesResponseType(typeof(PublicacionesResponse), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Patch(string descripcion, string ubicacion, string imagen, [FromBody] JsonPatchDocument<PublicacionesPermisos> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            //var existingItem = _publicacionesPresenter.Get(descripcion, ubicacion, imagen);
            //if (existingItem == null)
            //{
            //    return NotFound();
            //}

            //patchDoc.ApplyTo(existingItem);

            var result = await _publicacionesPresenter.Update(descripcion, ubicacion, imagen);
            return result != null ? Ok(result) : BadRequest();
        }
        // DELETE
        [HttpDelete]
        [Route("[controller]/[action]/{publicacion_id}")]
        [ProducesResponseType(typeof(void), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Delete(int publicacion_id)
        {
            var result = await _publicacionesPresenter.Delete(publicacion_id);
            return result ? Ok() : NotFound();
        }
    }
}

