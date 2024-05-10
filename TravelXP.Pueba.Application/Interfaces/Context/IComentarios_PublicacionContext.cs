using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO.DATA.Attributes;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.DTO.Response;
using TravelXP.Prueba.Domain.POCOS.Context;

namespace TravelXP.Pueba.Application.Interfaces.Context
{
    public interface IComentarios_PublicacionContext
    {
        public Task<List<EntityComentarios_PublicacionContext>> Get(string contenido);
        public Task<EntityResultContext> Post(string contenido);

        public Task<EntityResultContext> Update(string contenido);
        public Task<EntityResultContext> Delete(int id);
    }
}
