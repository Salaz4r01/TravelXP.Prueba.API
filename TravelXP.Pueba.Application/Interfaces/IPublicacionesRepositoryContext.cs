using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.POCOS.Context;

namespace TravelXP.Pueba.Application.Interfaces
{
    public interface IPublicacionesRepositoryContext
    {
        public Task<EntityPublicacionesContext> Get(int publicacion_id, int usuario_id, DateTime fecha,
            string imagen, string descripcion, string tipo_publicacion, string ubicacion);
        List<EntityPublicacionesContext> Get();
    }
}
