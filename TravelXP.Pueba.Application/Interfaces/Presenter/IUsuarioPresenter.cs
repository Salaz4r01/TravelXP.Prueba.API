using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.DTO.Response;

namespace TravelXP.Pueba.Application.Interfaces.Presenter
{
    public interface IUsuarioPresenter
    {
        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }
        public Task<UsuarioData> Get(int id, string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol);
        public Task<UsuarioData> Post(string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia, int rol);
        public Task<UsuarioData> Update(string nombre, string apellido, string nombre_usuario,
            string email, string contrasena, string foto_perfil, string biografia);
        public Task<UsuarioData> Delete(int id);
    }
}
