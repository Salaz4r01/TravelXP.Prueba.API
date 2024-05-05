using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelXP.Prueba.Domain.POCOS.Context
{
    public class EntityComentarios_PublicacionContext
    {

        public required string result { get; set; }
        public int code { get; set; }
        public int id { get; set; }
        public int publicacion_id { get; set; }
        public required int usuario_id { get; set; }
        public required string? contenido { get; set; }
        public required DateTime? fecha { get; set; }
    }
}
