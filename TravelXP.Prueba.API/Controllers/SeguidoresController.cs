using System.Net.Mime;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TravelXP.Prueba.Application.Presenters;
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
    public class SeguidoresController : ControllerBase
    {
        private readonly ISeguidoresPresenter _seguidoresPresenter;

        public SeguidoresController(ISeguidoresPresenter seguidoresPresenter)
        {
            _seguidoresPresenter = seguidoresPresenter;
        }

        // GET api/seguidores
        [HttpGet]
        [Route("[controller]/[action]/{seguidor_id}")]
        [ProducesResponseType(typeof(List<ISeguidoresPresenter>), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Get(int seguidor_id)
        {
            return Ok(await _seguidoresPresenter.Get(seguidor_id));
        }

        // POST api/seguidores
        [HttpPost]
        [Route("[controller]/[action]/{seguidor_id}")]
        [ProducesResponseType(typeof(SeguidoresResponse), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Post(int seguidor_id) // Especifica el tipo de datos para seguidor_id
        {
            var result = await _seguidoresPresenter.Post(seguidor_id);
            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { seguidor = result.attributes.seguidor_id }, result);
            }
            else
            {
                return BadRequest();
            }
        }
        // PATCH api/seguidores/{id}
        [HttpPatch("{seguidor_id}")]
        [ProducesResponseType(typeof(SeguidoresResponse), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Patch(int seguidor_id, [FromBody] JsonPatchDocument<SeguidoresPermisos> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var existingItem = _seguidoresPresenter.Get(seguidor_id);
            if (existingItem == null)
            {
                return NotFound();
            }

            //patchDoc.ApplyTo(existingItem);

            var result = await _seguidoresPresenter.Update(seguidor_id);
            return result != null ? Ok(result) : BadRequest();
        }
        // DELETE
        [HttpDelete]
        [Route("[controller]/[action]/{seguidor_id}")]
        [ProducesResponseType(typeof(void), (int)StatusResult.Success)]
        [ProducesResponseType(typeof(ErrorResponse), (int)StatusResult.badRequest)]
        public async Task<IActionResult> Delete(int seguidor_id)
        {
            var result = await _seguidoresPresenter.Delete(seguidor_id);
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

