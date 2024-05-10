using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.DTO.Response;

namespace TravelXP.Pueba.Application.Interfaces.Presenter
{
    public interface IComentarios_PublicacionPresenter
    {
        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }
        public Task<Comentarios_PublicacionData> Comentarios_Publicacion_GETAsync(string contenido);
        public ValueTask<Comentarios_PublicacionResponse> Post(string contenido);
        public  Task<Comentarios_PublicacionResponse> Update(string contenido);
        public Task<Comentarios_PublicacionResponse2> Delete(int id);
    }
}
