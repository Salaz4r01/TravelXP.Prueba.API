using TravelXP.Prueba.Domain.POCOS.Context;

namespace TravelXP.Pueba.Application.Interfaces
{
    public interface IUsuarioRepositoryContext
    {
        public Task<EntityUsuarioContext> Get(int id, string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol);
        List<EntityUsuarioContext> Get();
    }
}
