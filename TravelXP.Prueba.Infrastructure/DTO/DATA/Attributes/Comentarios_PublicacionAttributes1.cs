

namespace TravelXP.Prueba.Infrastructure.DTO.DATA.Attributes
{
    public class Comentarios_PublicacionAttributes1
    {
        public required int id { get; set; }
        public int publicacion_id { get; set; }
        public int usuario_id { get; set; }
        public required string contenido { get; set; }
        public required DateTime fecha { get; set; }
    }
}
