using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO.DATA.Attributes;

namespace TravelXP.Prueba.Domain.DTO.DATA
{
    public class UsuarioData
    {
        public int? type { get; set; }
        public UsuarioAttributes attributes { get; set; }
    }
}
