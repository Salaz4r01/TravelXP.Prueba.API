using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Pueba.Application.Interfaces;

namespace TravelXP.Pueba.Application.Presenters
{
    public class SeguidoresLogic
    {
        private readonly IRepositoryContext _seguidoresContext;

        public SeguidoresLogic(IRepositoryContext seguidoresContext)
        {
            _seguidoresContext = seguidoresContext ?? throw new ArgumentNullException(nameof(seguidoresContext));
        }

        public async Task<SeguidoresData> Get(int seguidor_id)
        {
            try
            {
                return await Get(seguidor_id);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al obtener las publicaciones.", ex);
            }
        }

        public async Task<SeguidoresData> Post(int seguidor_id)
        {
            try
            {
                return await Post(seguidor_id);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al crear la publicación.", ex);
            }
        }

        public async Task<PublicacionesData> Update(int seguidor_id)
        {
            try
            {
                return await Update(seguidor_id);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al actualizar la publicación.", ex);
            }
        }

        public async Task<bool> Delete(int seguidor_id)
        {
            try
            {
                return await Delete(seguidor_id);
            }
            catch (Exception ex)
            {
                // Registrar el error o lanzar una excepción más específica si es necesario
                throw new Exception("Error al eliminar la publicación.", ex);
            }
        }
    }
}
