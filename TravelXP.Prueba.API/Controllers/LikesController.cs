using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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
    public class LikesController : ControllerBase
    {
        private readonly ILikesPresenter _likesPresenter;

        public LikesController(ILikesPresenter likesPresenter)
        {
            _likesPresenter = likesPresenter;
        }

        // GET api/likes
        [HttpGet]
        [Route("[controller]/[action]/{id}/{usuario_id}/{publicacion_id}/{fecha}")]
        [ProducesResponseType(typeof(List<ILikesPresenter>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Get(int id, int usuario_id, int publicacion_id, DateTime fecha)
        {
            // Validar la entrada
            if (id <= 0 || usuario_id <= 0 || publicacion_id <= 0)
            {
                return BadRequest("Los parámetros de entrada son inválidos.");
            }

            // Obtener los likes
            var likes = await _likesPresenter.Get(id, usuario_id, publicacion_id, fecha);

            return Ok(likes);
        }
        // GET api/likes
        [HttpGet]
        [Route("[controller]/[action]/{usuario_id}")]
        [ProducesResponseType(typeof(List<ILikesPresenter>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> GetLikes(int usuario_id)
        {
            // Validar la entrada
            if (usuario_id <= 0)
            {
                return BadRequest("Los parámetros de entrada son inválidos.");
            }

            // Obtener los likes
            var likes = await _likesPresenter.GetLikes(usuario_id);

            return Ok(likes);
        }

        // POST api/likes
        [HttpPost]
        [Route("[controller]/[action]/{usuario_id}")]
        [ProducesResponseType(typeof(LikesResponse), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Post(LikesPermisos post)
        {
            // Validar la entrada
            if (post == null)
            {
                return BadRequest("La solicitud de like es nula.");
            }

            // Procesar el nuevo like
            var result = await _likesPresenter.Post(post);
            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { id = result.attributes.usuario_id }, result);
            }
            else
            {
                return BadRequest("No se pudo crear el like.");
            }
        }

        // PATCH api/likes/{usuario_id}
        [HttpPatch]
        [Route("[controller]/[action]/{usuario_id}")]
        [ProducesResponseType(typeof(LikesResponse), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Patch(int usuario_id, [FromBody] JsonPatchDocument<LikesPermisos> patchDoc)
        {
            // Validar la entrada
            if (patchDoc == null)
            {
                return BadRequest("El documento de parche JSON es nulo.");
            }

            // Obtener el like existente
            var existingItem = _likesPresenter.GetLikes(usuario_id);
            if (existingItem == null)
            {
                return NotFound("El like no se encontró.");
            }

            // Convertir existingItem a JObject
            var existingItemJson = JObject.FromObject(existingItem);

            // Aplicar el parche al JObject
            //patchDoc.ApplyTo(existingItemJson);

            // Convertir el JObject actualizado de vuelta a LikesPermisos
            var updatedItem = existingItemJson.ToObject<LikesPermisos>();

            // Actualizar el like
            var result = await _likesPresenter.Update(usuario_id, updatedItem);
            return result != null ? Ok(result) : BadRequest("No se pudo actualizar el like.");
        }

        // DELETE api/likes/{id}
        [HttpDelete]
        [Route("[controller]/[action]/{id}")]
        [ProducesResponseType(typeof(void), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            // Validar la entrada
            if (id <= 0)
            {
                return BadRequest("El ID del like es inválido.");
            }

            // Eliminar el like
            var result = await _likesPresenter.Delete(id);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound("El like no se encontró o no se pudo eliminar.");
            }
        }
    }
}
