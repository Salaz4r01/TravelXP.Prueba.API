using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.DTO.Response;

namespace TravelXP.Pueba.Application.Interfaces.Presenter
{
    public interface IPublicacionesPresenter
    {
        //public List<string> _error { get; set; }
        //public ErrorResponse _errorResponse { get; set; }
        public Task<PublicacionesData> Get(int publicacion_id, int usuario_id, DateTime fecha, string imagen, string descripcion, string tipo_publicacion, string ubicacion);
        public Task<PublicacionesData> Post(string descripcion, string imagen, string ubicacion);
        public Task<PublicacionesData> Update(string descripcion, string ubicacion, string imagen);
        public Task<bool> Delete(int publicacion_id);

    }
}
