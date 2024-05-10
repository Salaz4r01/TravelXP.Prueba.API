using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.DTO.Response;
using TravelXP.Pueba.Application.Interfaces.Presenter;
using TravelXP.Pueba.Application.Interfaces;
using TravelXP.Pueba.Application.Interfaces.Context;

namespace TravelXP.Pueba.Application.Presenters
{
    public class LikesLogic : ILikesPresenter
    {
        private readonly IRepositoryContext _likesRepository;

        public LikesLogic(IRepositoryContext likesRepository)
        {
            _likesRepository = likesRepository ?? throw new ArgumentNullException(nameof(likesRepository));
        }

        public async Task<LikesData> Get(int id, int usuario_id, int publicacion_id, DateTime fecha)
        {
            try
            {
                return await _likesRepository.LikesContext.Get(id, usuario_id, publicacion_id, fecha);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al obtener los likes.", ex);
            }
        }

        public async Task<LikesData> GetLikes(int usuario_id)
        {
            try
            {
                return await _likesRepository.LikesContext.GetLikes(usuario_id);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al obtener los likes del usuario.", ex);
            }
        }

        public async Task<LikesData> Post(LikesPermisos post)
        {
            try
            {
                return await _likesRepository.LikesContext.Post(post);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al crear el like.", ex);
            }
        }

        public async Task<LikesData> Update(int usuario_id, LikesPermisos like)
        {
            try
            {
                return await _likesRepository.LikesContext.Update(usuario_id, like);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al actualizar el like.", ex);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _likesRepository.LikesContext.Delete(id);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al eliminar el like.", ex);
            }
        }
    }
}
