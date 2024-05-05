using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.POCOS.Context;

namespace TravelXP.Pueba.Application.Interfaces
{
    public interface ILikesRepositoryContext
    {
        public Task<EntityLikesContext> Get(int id, int usuario_id, int publicacion_id, DateTime fecha);
        public Task<EntityLikesContext> GetLikes(int usuario_id);
    }
}
