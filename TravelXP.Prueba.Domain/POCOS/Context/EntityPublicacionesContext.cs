using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelXP.Prueba.Domain.POCOS.Context
{
    public class EntityPublicacionesContext
    {
        public required string result { get; set; }
        public int code { get; set; }
        public int publicacion_id { get; set; }
        public int usuario_id { get; set; }
        public DateTime fecha { get; set; }
        public string imagen { get; set; }
        public string descripcion { get; set; }
        public string tipo_publicacion { get; set; }
        public string ubicacion { get; set; }
    }
}
