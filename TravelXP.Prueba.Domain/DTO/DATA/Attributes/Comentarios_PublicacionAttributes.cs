using System;

namespace TravelXP.Prueba.Domain.DTO.DATA.Attributes
{
    public class Comentarios_PublicacionAttributes
    {
        public string result { get; set; }
        public int code { get; set; }
        public int id { get; set; }
        public int publicacion_id { get; set; }
        public int usuario_id { get; set; }
        public string? contenido { get; set; }
        public DateTime fecha { get; set; }
    }
}
