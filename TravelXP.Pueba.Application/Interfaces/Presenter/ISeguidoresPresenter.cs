using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Prueba.Domain.DTO.Response;

namespace TravelXP.Pueba.Application.Interfaces.Presenter
{
    public interface ISeguidoresPresenter
    {
        public List<string> _error { get; set; }
        public ErrorResponse _errorResponse { get; set; }

        public Task<SeguidoresData> Get(int seguidor_id);
        public Task<SeguidoresData> Post(int seguidor_id);
        public Task<SeguidoresData> Update(int seguidor_id);
        public Task<SeguidoresData> Delete(int seguidor_id);
    }
}
