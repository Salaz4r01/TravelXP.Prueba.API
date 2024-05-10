
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.POCOS.Context;

namespace TravelXP.Pueba.Application.Interfaces.Context
{
    public interface IUsuarioContext
    {
        public Task<List<EntityResultContext>> Get(int id, string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol);
        public Task<EntityResultContext> Post(string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol);
        public Task<EntityResultContext> Update(string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia);
        public Task<EntityResultContext> Delete(int id);
    }
}
