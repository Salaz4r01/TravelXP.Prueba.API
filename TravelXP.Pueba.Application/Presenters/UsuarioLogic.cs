using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Pueba.Application.Interfaces;

namespace TravelXP.Pueba.Application.Presenters
{
    public class UsuarioLogic
    {
        private readonly IRepositoryContext _usuarioContext;

        public UsuarioLogic(IRepositoryContext usuarioContext)
        {
            _usuarioContext = usuarioContext ?? throw new ArgumentNullException(nameof(usuarioContext));
        }

        public async Task<UsuarioData> Get(int id, string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol)
        {
            try
            {
                return await Get(id, nombre, apellido, nombre_usuario, email, contrasena, foto_perfil, biografia, rol);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al obtener las publicaciones.", ex);
            }
        }

        public async Task<UsuarioData> Post(string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol)
        {
            try
            {
                return await Post(nombre, apellido, nombre_usuario, email, contrasena, foto_perfil, biografia, rol);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al crear la publicación.", ex);
            }
        }

        public async Task<PublicacionesData> Update(string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia)
        {
            try
            {
                return await Update(nombre, apellido, nombre_usuario, email, contrasena, foto_perfil, biografia);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al actualizar la publicación.", ex);
            }
        }

        public async Task<UsuarioData> Delete(int id)
        {
            try
            {
                return await Delete(id);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al eliminar la publicación.", ex);
            }
        }
    }
}
