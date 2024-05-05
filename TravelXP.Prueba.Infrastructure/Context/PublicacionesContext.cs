using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnectionExample;
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.Enums;
using TravelXP.Prueba.Domain.POCOS.Context;
using TravelXP.Prueba.Infrastructure.DTO;
using TravelXP.Pueba.Application.Interfaces.Context;

namespace TravelXP.Prueba.Infrastructure.Context
{
    public class PublicacionesContext : IPublicacionesContext
    {
        private readonly BDServices _bDservices;
        public ErrorData _errorData { get; set; }

        public PublicacionesContext(BDServices services)
        {
            _bDservices = services;
        }

        public async Task<List<EntityPublicacionesContext>> Get(int publicacion_id, int usuario_id, DateTime fecha, string imagen, string descripcion, string tipo_publicacion, string ubicacion)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@id", publicacion_id, System.Data.DbType.Int64);
            dp.Add("@usuario_id", usuario_id, System.Data.DbType.Int64);
            dp.Add("@fecha", fecha, System.Data.DbType.DateTime);
            dp.Add("@imagen", imagen, System.Data.DbType.String);
            dp.Add("@descripcion", publicacion_id, System.Data.DbType.String);
            dp.Add("@tipo_publicacion", tipo_publicacion, System.Data.DbType.String);
            dp.Add("@ubicacion", publicacion_id, System.Data.DbType.String);
            var publicaciones2 = await _bDservices.ExecuteStoredProcedureQueryAsync<EntityPublicacionesContext>("get_BuscarPublicacionPorID", dp);
            List<EntityPublicacionesContext> lista = publicaciones2.ToList();
            if (publicaciones2.Count() > 0)
            {
                switch (publicaciones2.First().code)
                {
                    case (int)StatusResult.Success:
                        return lista;
                    case (int)StatusResult.badRequest:
                        return new List<EntityPublicacionesContext>(); // Devuelve una lista vacía
                    default:
                        return new List<EntityPublicacionesContext>(); // Devuelve una lista vacía
                }
            }
            return new List<EntityPublicacionesContext>(); // Devuelve una lista vacía
        }

        public async Task<EntityPublicacionesContext> Post(string imagen, string descripcion, string tipo_publicacion, string ubicacion)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@imagen", imagen, System.Data.DbType.String);
            dpr.Add("@descripcion", descripcion, System.Data.DbType.String);
            dpr.Add("@tipo_publicacion", tipo_publicacion, System.Data.DbType.String);
            dpr.Add("@ubicacion", ubicacion, System.Data.DbType.String);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityPublicacionesContext>("post_InsertarPublicacion", dpr);
            if (result.code == 200)
                return result;
            else
            {
                _errorData = new ErrorData
                {
                    code = result.code.ToString(),
                    title = "ERROR",
                    detail = result.result,
                    status = result.code
                };
                return null;
            }
        }

        public async Task<EntityPublicacionesContext> Update(string descripcion, string imagen, string ubicacion)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@descripcion", descripcion, System.Data.DbType.String);
            dp.Add("@imagen", imagen, System.Data.DbType.String);
            dp.Add("@ubicacion", ubicacion, System.Data.DbType.String);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityPublicacionesContext>("put_EditarPublicacion", dp);
            return result; // Devuelve directamente el objeto EntityPublicacionesContext
        }


        public async Task<EntityPublicacionesContext> Delete(int publicacion_id)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@publicacion_id", publicacion_id, System.Data.DbType.Int64);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityPublicacionesContext>("delete_EliminarPublicacion", dp);
            return result;
        }
    }
}
