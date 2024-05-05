using TravelXP.Prueba.Domain.POCOS.Context;

namespace TravelXP.Pueba.Application.Interfaces
{
    public interface ISeguidoresRepositoryContext
    {
        public Task<EntitySeguidoresContext> Get(int id, int seguido_id, DateTime fecha_seguimiento);
        List<EntitySeguidoresContext> Get(int id, List<EntitySeguidoresContext> seguidores, List<EntitySeguidoresContext> EntitySeguidoresContexts);
        List<EntitySeguidoresContext> Get();
        public EntitySeguidoresContext GetSeguidores();
    }
}
