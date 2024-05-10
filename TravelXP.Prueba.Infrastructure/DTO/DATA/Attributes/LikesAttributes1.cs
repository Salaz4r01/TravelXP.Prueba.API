

namespace TravelXP.Prueba.Infrastructure.DTO.DATA.Attributes
{
    public class LikesAttributes1
    {
        public int id { get; set; }
        public required int usuario_id { get; set; }
        public required int publicacion_id { get; set; }
        public required DateTime fecha { get; set; }
    }
}
