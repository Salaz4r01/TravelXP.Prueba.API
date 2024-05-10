using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO.DATA.Attributes;

namespace TravelXP.Prueba.Infrastructure.DTO.DATA
{
    public class UsuarioData
    {
        public required int id { get; set; }
        public required List <UsuarioAttributes1> attributes { get; set; }
    }
}
