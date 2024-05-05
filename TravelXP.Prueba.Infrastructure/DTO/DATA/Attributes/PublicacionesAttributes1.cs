using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelXP.Prueba.Infrastructure.DTO.DATA.Attributes
{
    public class PublicacionesAttributes1
    {
        public required int publicacion_id { get; set; }
        public required int usuario_id { get; set; }
        public required DateTime fecha { get; set; }
        public string? imagen { get; set; }
        public string? descripcion { get; set; }
        public required string? tipo_publicacion { get; set; }
        public required string? ubicacion { get; set; }
    }
}
