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
        public Task<List<EntityPublicacionesContext>> Get(int publicacion_id, int usuario_id, DateTime fecha, string imagen, string descripcion, string tipo_publicacion, string ubicacion);
        public Task<EntityPublicacionesContext> Post(string imagen, string descripcion, string tipo_publicacion, string ubicacion);
        public Task<EntityPublicacionesContext> Update(string descripcion, string imagen, string ubicacion);
        public Task<EntityPublicacionesContext> Delete(int publicacion_id);
    }
}
