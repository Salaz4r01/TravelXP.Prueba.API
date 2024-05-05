using Dapper;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.POCOS.Context;
using TravelXP.Pueba.Application.Interfaces.Context;
using System.Data;
using TravelXP.Prueba.Domain.DTO.DATA.Attributes;
using TravelXP.Prueba.Domain.DTO.DATA;
using MySqlConnectionExample;
using TravelXP.Prueba.Domain.DTO.Response;

namespace TravelXP.Prueba.Infrastructure.Context
{
    public class LikesContext : ILikesContext
    {
        private readonly BDServices _bDservices;
        public ErrorData _errorData { get; set; }

        public LikesContext(BDServices services)
        {
            _bDservices = services;
        }

        public async Task<LikesData> GetLikes(int id)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@id", id);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<LikesData>("get_CantidadLikes", dp);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Error al obtener los likes.");
            }
        }

        public async Task<LikesData> Get(int id, int usuario_id, int publicacion_id, DateTime fecha)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@id", id);
            dp.Add("@usuario_id", usuario_id);
            dp.Add("@publicacion_id", publicacion_id);
            dp.Add("@fecha", fecha);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<LikesData>("create_Like", dp);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Error al crear el like.");
            }
        }

        public async Task<LikesData> Post(LikesPermisos post)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@usuario_id", post.data.attributes.usuario_id);
            dp.Add("@publicacion_id", post.data.attributes.publicacion_id);
            dp.Add("@fecha", post.data.attributes.fecha);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<LikesData>("post_InsertarLike", dp);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Error al crear el like.");
            }
        }

        public async Task<LikesData> Update(int id, LikesPermisos like)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@id", id);
            dp.Add("@usuario_id", like.data.attributes.usuario_id);
            dp.Add("@publicacion_id", like.data.attributes.publicacion_id);
            dp.Add("@fecha", like.data.attributes.fecha);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<LikesData>("put_Like", dp);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Error al actualizar el like.");
            }
        }

        public async Task<bool> Delete(int id)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@id", id);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<bool>("delete_Like", dp);

            if (result != null)
            {
                return result;
            }
            else
            {
                throw new Exception("Error al eliminar el like.");
            }
        }

    }
}
