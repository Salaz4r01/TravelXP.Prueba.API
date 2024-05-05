using Dapper;
using TravelXP.Prueba.Domain.DTO.DATA.Attributes;
using TravelXP.Prueba.Domain.POCOS.Context;

using TravelXP.Pueba.Application.Interfaces;
using TravelXP.Pueba.Application.Interfaces.Context;
using TravelXP.Prueba.Domain.Enums;
using MySqlConnectionExample;
using FluentAssertions.Common;
using TravelXP.Prueba.Infrastructure.DTO;
using TravelXP.Prueba.Domain.DTO.DATA;
using System.Runtime.Intrinsics.Arm;


namespace TravelXP.Prueba.Infrastructure.Context
{
    public class UsuarioContext : IUsuarioContext
    {
        private readonly BDServices _bDservices;
        public ErrorData _errorData { get; set; }

        public UsuarioContext(BDServices services)
        {
            _bDservices = services;
        }

        public async Task<List<EntityResultContext>> Get(int id, string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@id", id, System.Data.DbType.Int64);
            dp.Add("@nombre", nombre, System.Data.DbType.String);
            dp.Add("@apellido", apellido, System.Data.DbType.String);
            dp.Add("@nombre_usuario", nombre_usuario, System.Data.DbType.String);
            dp.Add("@email", email, System.Data.DbType.String);
            dp.Add("@contrasena", contrasena, System.Data.DbType.String);
            dp.Add("@foto_perfil", foto_perfil, System.Data.DbType.String);
            dp.Add("@biografia", biografia, System.Data.DbType.String);
            dp.Add("@rol", contrasena, System.Data.DbType.Int64);
            var usuario2 = await _bDservices.ExecuteStoredProcedureQueryAsync<EntityResultContext>("get_BuscarUsuarioPorNombreUsuario", dp);
            List<EntityResultContext> lista = usuario2.ToList();
            if (usuario2.Count() > 0)
            {
                switch (usuario2.First().code)
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


        public async Task<EntityResultContext> Post(string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@nombre", nombre, System.Data.DbType.String);
            dp.Add("@apellido", apellido, System.Data.DbType.String);
            dp.Add("@nombre_usuario", nombre_usuario, System.Data.DbType.String);
            dp.Add("@email", email, System.Data.DbType.String);
            dp.Add("@contrasena", contrasena, System.Data.DbType.String);
            dp.Add("@foto_perfil", foto_perfil, System.Data.DbType.String);
            dp.Add("@biografia", biografia, System.Data.DbType.String);
            dp.Add("@rol", contrasena, System.Data.DbType.Int64);
            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("post_InsertarUsuario", dp);
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
        public async Task<EntityResultContext> Update(string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@nombre", nombre, System.Data.DbType.String);
            dp.Add("@apellido", apellido, System.Data.DbType.String);
            dp.Add("@nombre_usuario", nombre_usuario, System.Data.DbType.String);
            dp.Add("@email", email, System.Data.DbType.String);
            dp.Add("@contrasena", contrasena, System.Data.DbType.String);
            dp.Add("@foto_perfil", foto_perfil, System.Data.DbType.String);
            dp.Add("@biografia", biografia, System.Data.DbType.String);
            dp.Add("@rol", contrasena, System.Data.DbType.Int64);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("put_InsertarUsuario", dp);
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
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@id", id, System.Data.DbType.Int64);

            var result = await _bDservices.ExecuteStoredProcedureQueryFirstOrDefault<EntityResultContext>("delete_EliminarUsuario", dp);
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


