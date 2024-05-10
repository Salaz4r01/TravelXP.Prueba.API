using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO.DATA.Attributes;

namespace TravelXP.Prueba.Infrastructure.DTO.DATA
{
    public class Comentarios_PublicacionData
    {
        public required int id { get; set; }
        public Task<Comentarios_PublicacionAttributes> attributes { get; set; }
    }
}
