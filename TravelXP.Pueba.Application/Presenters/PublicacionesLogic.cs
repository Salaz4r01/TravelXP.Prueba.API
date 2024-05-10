using TravelXP.Prueba.Domain.DTO.DATA.Attributes;
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Response;
using TravelXP.Prueba.Domain.POCOS.Context;
using TravelXP.Pueba.Application.Interfaces;
using TravelXP.Pueba.Application.Interfaces.Context;
using TravelXP.Pueba.Application.Interfaces.Presenter;

namespace TravelXP.Prueba.Application.Presenters
{
    public class PublicacionesLogic : IPublicacionesPresenter
    {
        //private readonly IRepositoryContext _publicacionesContext;

        //public PublicacionesLogic(IRepositoryContext publicacionesContext)
        //{
        //    _publicacionesContext = publicacionesContext ?? throw new ArgumentNullException(nameof(publicacionesContext));
        //}
        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }

        private readonly IRepositoryContext _publicacionesContext;

        public PublicacionesLogic(IRepositoryContext publicacionesRepository)
        {
            _error = new List<string>();
            _errorResponse = new ErrorResponse();
            _publicacionesContext = publicacionesRepository;
        }

        public async Task<EntityPublicacionesContext> Get(int publicacion_id, int usuario_id, string descripcion, string ubicacion)
        {
            if (publicacion_id <= 0)
            {
                return null;
            }
            if (publicacion_id >= 1)
            {
                _error.Add("La publicacion debe tener un ID mayor a 0");
                return null;
            }

            var result = await _publicacionesContext.PublicacionContext.Get(publicacion_id, usuario_id, descripcion, ubicacion);

            List<EntityPublicacionesContext> publicaciones = result.ToList();
            if (publicaciones.Count > 0 && publicaciones[0].code == 200)
            {
                List<PublicacionesAttributes> publicaciones1 = new();
                foreach (var publicacionesA in publicaciones)
                {
                    publicaciones1.Add(new PublicacionesAttributes
                    {
                        publicacion_id = publicacionesA.publicacion_id,
                        usuario_id = publicacionesA.usuario_id,
                        fecha = (DateTime)publicacionesA.fecha,
                        descripcion = publicacionesA.descripcion,
                        tipo_publicacion = publicacionesA.tipo_publicacion,
                        ubicacion = publicacionesA.ubicacion,
                    });
                }
                // Crear una instancia de EntityPublicacionesContext con un valor de resultado apropiado
                return new EntityPublicacionesContext
                {
                    result = "OK", // O el valor apropiado
                    publicaciones = publicaciones1
                };
            }
            else
            {
                // Manejar el error adecuadamente aquí
                return null;
            }
        }
        public async Task<EntityPublicacionesContext> Post(string descripcion, string ubicacion)
        {
            try
            {
                return await _publicacionesContext.PublicacionContext.Post(descripcion, ubicacion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la publicación.", ex);
            }
        }
        public async Task<PublicacionesResponse> Update(string descripcion, string ubicacion)
        {
            try
            {
                var updatedItem = await _publicacionesContext.PublicacionContext.Update(descripcion, ubicacion);

                var response = new PublicacionesResponse();

                response.data = new PublicacionesData
                {
                    attributes = new PublicacionesAttributes
                    {
                        result = "Success", // Si la operación de actualización tiene éxito
                        code = 200 // Código de éxito
                    }
                };

                return response;
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante la actualización
                var response = new PublicacionesResponse();

                response.data = new PublicacionesData
                {
                    attributes = new PublicacionesAttributes
                    {
                        result = "Error", // Indicar que hubo un error
                        code = 500, // Código de error interno del servidor
                    }
                };

                return response;
            }
        }

        public async Task<EntityPublicacionesContext> Delete(int publicacion_id)
        {
            try
            {
                return await _publicacionesContext.PublicacionContext.Delete(publicacion_id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la publicación.", ex);
            }
        }
    }
}
