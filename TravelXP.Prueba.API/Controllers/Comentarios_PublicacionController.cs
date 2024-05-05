using System.Net.Mime;
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
    [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
    public class Comentarios_PublicacionController : ControllerBase
    {
        private readonly IComentarios_PublicacionPresenter _comentarios_PublicacionPresenter;

        public Comentarios_PublicacionController(IComentarios_PublicacionPresenter comentarios_PublicacionPresenter)
        {
            _comentarios_PublicacionPresenter = comentarios_PublicacionPresenter;
        }

        [HttpGet]
        [Route("[controller]/[action]/{contenido}")]
        [ProducesResponseType(typeof(IEnumerable<IComentarios_PublicacionPresenter>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Comentarios_Publicacion_GETAsync(string contenido)
        {
            var comentarios = await _comentarios_PublicacionPresenter.Comentarios_Publicacion_GETAsync(contenido);
            if (comentarios == null)
            {
                return NotFound();
            }
            return Ok(comentarios);
        }
        // POST api/comentarios_publicacion
        [HttpPost]
        [Route("[controller]/[action]/{contenido}")]
        [ProducesResponseType(typeof(Comentarios_PublicacionResponse), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Post(string contenido)
        {
            var result = await _comentarios_PublicacionPresenter.Post(contenido);
            if (result != null)
            {
                return CreatedAtAction(nameof(Comentarios_Publicacion_GETAsync), new { contenido = result.data.attributes.contenido }, result);
            }
            else
            {
                return BadRequest();
            }
        }
        // PATCH api/comentarios_publicacion/{id}
        [HttpPatch]
        [Route("[controller]/[action]/{contenido}")]
        [ProducesResponseType(typeof(Comentarios_PublicacionResponse), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Patch(string contenido, [FromBody] JsonPatchDocument<Comentarios_PublicacionPermisos> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }
            var result = await _comentarios_PublicacionPresenter.Update(contenido);
            return result != null ? Ok(result) : BadRequest();
        }
        // DELETE api/comentarios_publicacion/{publicacion_id}
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _comentarios_PublicacionPresenter.Delete(id);
            return result.data2 != null ? NoContent() : BadRequest();
        }

    }
}
