using Microsoft.AspNetCore.JsonPatch;
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.DTO.Response;
using TravelXP.Prueba.Domain.POCOS.Context;
using static System.Net.Mime.MediaTypeNames;

namespace TravelXP.Pueba.Application.Interfaces.Presenter
{
    public interface IPublicacionesPresenter
    {
        //public List<string> _error { get; set; }
        //public ErrorResponse _errorResponse { get; set; }
        public Task<EntityPublicacionesContext> Get(int publicacion_id, int usuario_id, string descripcion, string ubicacion);
        public Task<EntityPublicacionesContext> Post(string descripcion, string ubicacion);
        public Task<PublicacionesResponse> Update(string descripcion, string ubicacion);
        public Task<EntityPublicacionesContext> Delete(int publicacion_id);

        //public Task<PublicacionesData> Get(int publicacion_id, int usuario_id, DateTime fecha, string imagen, string descripcion, string ubicacion);
        //public Task<PublicacionesData> Post(string descripcion, string ubicacion, string imagen);
        //public Task<PublicacionesData> Update(string descripcion, string ubicacion, string imagen);
        //public Task<PublicacionesData> Delete(int publicacion_id);
    }
}
