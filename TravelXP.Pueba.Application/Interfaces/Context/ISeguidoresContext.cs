
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.POCOS.Context;

namespace TravelXP.Pueba.Application.Interfaces.Context
{
    public interface ISeguidoresContext
    {
        public Task<List<EntityResultContext>> Get(int seguidor_id);
        public Task<EntityResultContext> Post(int seguidor_id);
        public Task<EntityResultContext> Update(int seguidor_id);
        public Task<EntityResultContext> Delete(int seguidor_id);
    }
}
