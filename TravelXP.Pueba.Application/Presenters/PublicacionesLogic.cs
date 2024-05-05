using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Pueba.Application.Interfaces;
using TravelXP.Pueba.Application.Interfaces.Presenter;

namespace TravelXP.Prueba.Application.Presenters
{
    public class PublicacionesLogic : IPublicacionesPresenter
    {
        private readonly IRepositoryContext _publicacionesContext;

        public PublicacionesLogic(IRepositoryContext publicacionesContext)
        {
            _publicacionesContext = publicacionesContext ?? throw new ArgumentNullException(nameof(publicacionesContext));
        }

        public async Task<PublicacionesData> Get(int publicacion_id, int usuario_id, DateTime fecha, string imagen, string descripcion, string tipo_publicacion, string ubicacion)
        {
            try
            {
                return await Get(publicacion_id, usuario_id, fecha, imagen, descripcion, tipo_publicacion, ubicacion);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al obtener las publicaciones.", ex);
            }
        }

        public async Task<PublicacionesData> Post(string descripcion, string imagen, string ubicacion)
        {
            try
            {
                return await Post(descripcion, imagen, ubicacion);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al crear la publicación.", ex);
            }
        }

        public async Task<PublicacionesData> Update(string descripcion, string ubicacion, string imagen)
        {
            try
            {
                return await Update(descripcion, ubicacion, imagen);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al actualizar la publicación.", ex);
            }
        }

        public async Task<bool> Delete(int publicacion_id)
        {
            try
            {
                return await Delete(publicacion_id);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al eliminar la publicación.", ex);
            }
        }
    }
}
