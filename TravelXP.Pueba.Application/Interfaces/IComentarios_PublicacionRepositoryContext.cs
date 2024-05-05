using TravelXP.Prueba.Domain.POCOS.Context;

namespace TravelXP.Pueba.Application.Interfaces
{
    public interface IComentarios_PublicacionRepositoryContext
    {
        public Task<List<EntityComentarios_PublicacionContext>> Get(int publicacion_id);
        object? Get(int id, int publicacion_id, int usuario_id, string contenido, DateTime fecha);
        List<EntityComentarios_PublicacionContext> GetComentarios_Publicacion();
    }
}
