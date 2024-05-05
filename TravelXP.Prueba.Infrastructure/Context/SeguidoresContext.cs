using Dapper;
using MySqlConnectionExample;
using TravelXP.Prueba.Domain.Enums;
using TravelXP.Prueba.Domain.POCOS.Context;
using TravelXP.Pueba.Application.Interfaces.Context;
using System.Linq;
using System.Collections.Generic;
using TravelXP.Prueba.Domain.DTO.DATA;

namespace TravelXP.Prueba.Infrastructure.Context
{
    public class SeguidoresContext : ISeguidoresContext
    {
        private readonly BDServices _bDservices;
        public ErrorData _errorData { get; set; }

        public SeguidoresContext(BDServices services)
        {
            _bDservices = services;
        }

        public async Task<List<EntityResultContext>> Get(int seguidor_id)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@seguidor_id", seguidor_id, System.Data.DbType.Int64);
            var seguidor2 = await _bDservices.ExecuteStoredProcedureQueryAsync<EntityResultContext>("get_Seguidores", dp);
            List<EntityResultContext> lista = seguidor2.ToList();
            if (seguidor2.Count() > 0)
            {
                switch (seguidor2.First().code)
                {
                    case (int)StatusResult.Success:
                        return lista;
                    case (int)StatusResult.badRequest:
                    default:
                        return new List<EntityResultContext>();
                }
            }
            return new List<EntityResultContext>();
        }


        public async Task<EntityResultContext> Post(int seguidor_id)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@seguidor_id", seguidor_id, System.Data.DbType.Int64);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("post_SeguirUsuario", dpr);
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
        public async Task<EntityResultContext> Update(int seguidor_id)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@seguidor_id", seguidor_id, System.Data.DbType.String);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("put_SeguirUsuario", dpr);
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
        public async Task<EntityResultContext> Delete(int seguidor_id)
        {
            DynamicParameters dpr = new DynamicParameters();
            dpr.Add("@seguidor_id", seguidor_id, System.Data.DbType.Int64);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("delete_SeguirUsuario", dpr);
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
