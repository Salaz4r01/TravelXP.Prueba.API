using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.DTO.Response;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TravelXP.Pueba.Application.Interfaces.Presenter
{
    public interface ILikesPresenter
    {
            //public List<string> _error { get; set; }
            //public ErrorResponse _errorResponse { get; set; }
            public Task<LikesData> Get(int id, int usuario_id, int publicacion_id, DateTime fecha);
            public Task<LikesData> GetLikes(int usuario_id);
            public Task<LikesData> Post(LikesPermisos post);
            public Task<LikesData> Update(int usuario_id, LikesPermisos like);
            public Task<bool> Delete(int id);
        

    }
}
