using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.DTO.Response;
using TravelXP.Prueba.Domain.POCOS.Context;

namespace TravelXP.Pueba.Application.Interfaces.Context
{
    public interface ILikesContext
    {
        public Task<LikesData> Get(int id, int usuario_id, int publicacion_id, DateTime fecha);
        public Task<LikesData> GetLikes(int usuario_id);
        public Task<LikesData> Post(LikesPermisos post);
        public Task<LikesData> Update(int usuario_id, LikesPermisos like);
        public Task<bool> Delete(int id);
    }
}
