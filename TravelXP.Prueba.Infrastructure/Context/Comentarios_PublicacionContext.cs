using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using TravelXP.Prueba.Domain.Enums;
using TravelXP.Prueba.Domain.POCOS.Context;
using TravelXP.Pueba.Application.Interfaces;
using MySqlConnectionExample;
using TravelXP.Pueba.Application.Interfaces.Context;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Pueba.Application.Interfaces.Presenter;
using TravelXP.Pueba.Application.Presenters;
using TravelXP.Prueba.Domain.DTO.Response;
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.DATA.Attributes;
using Mysqlx.Crud;

namespace TravelXP.Prueba.Infrastructure.Context
{
    public class Comentarios_PublicacionContext : IComentarios_PublicacionContext
    {
        private readonly BDServices _bDservices;

        public ErrorData _errorData {  get; set; }

        public Comentarios_PublicacionContext(BDServices services)
        {
            _bDservices = services;
        }

        public async Task<List<EntityComentarios_PublicacionContext>> Get(string contenido)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@contenido", contenido, System.Data.DbType.String);
            var comentarios_Publicacion2 = await _bDservices.ExecuteStoredProcedureQueryAsync<EntityComentarios_PublicacionContext>("get_ObtenerComentario", dp);
            List<EntityComentarios_PublicacionContext> lista = comentarios_Publicacion2.ToList();
            if (comentarios_Publicacion2.Count() > 0)
            {
                switch (comentarios_Publicacion2.First().code)
                {
                    case (int)StatusResult.Success:
                        return lista;
                    case (int)StatusResult.badRequest:
                    default:
                        return new List<EntityComentarios_PublicacionContext>();
                }
            }
            return new List<EntityComentarios_PublicacionContext>();
        }

        public async Task<EntityResultContext> Post(string contenido)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@contenido", contenido, System.Data.DbType.String);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("post_InsertarComentario", dpr);
            if (result.code == 200)
                return result;
            else
            {

                _errorData.code = result.code.ToString();
                _errorData.title = "ERROR";
                _errorData.detail = result.result;
                _errorData.status = result.code;
                return null;
            }
        }
        public async Task<EntityResultContext> Update(string contenido)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@contenido", contenido, System.Data.DbType.String);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("put_EditarComentario", dpr);
            if (result.code == 200)
                return result;
            else
            {

                _errorData.code = result.code.ToString();
                _errorData.title = "ERROR";
                _errorData.detail = result.result;
                _errorData.status = result.code;
                return null;
            }
        }
        public async Task<EntityResultContext> Delete(int id)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@id", id, System.Data.DbType.Int64);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("delete_EliminarComentario", dpr);
            if (result.code == 200)
                return result;
            else
            {
                _errorData.code = result.code.ToString();
                _errorData.title = "ERROR";
                _errorData.detail = result.result;
                _errorData.status = result.code;
                return null;
            }
        }
    }
}
