using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelXP.Prueba.Domain.POCOS.Context
{
    public class EntitySeguidoresContext
    {
        public string result { get; set; }
        public int code { get; set; }
        public int id { get; set; }
        public required int seguidor_id { get; set; }
        public required int seguido_id { get; set; }
        public required DateTime fecha_seguimiento { get; set; }
    }
}
