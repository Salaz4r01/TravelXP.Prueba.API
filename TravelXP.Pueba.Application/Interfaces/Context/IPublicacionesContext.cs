using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.POCOS.Context;

namespace TravelXP.Pueba.Application.Interfaces.Context
{
    public interface IPublicacionesContext
    {
        public Task<List<EntityPublicacionesContext>> Get(int publicacion_id, int usuario_id, string descripcion, string ubicacion);
        public Task<List<EntityPublicacionesContext>> Get_D(string descripcion, string ubicacion);
        public Task<EntityPublicacionesContext> Post(string descripcion, string ubicacion);
        public Task<EntityPublicacionesContext> Update(string descripcion, string ubicacion);
        public Task<EntityPublicacionesContext> Delete(int publicacion_id);
    }
}
