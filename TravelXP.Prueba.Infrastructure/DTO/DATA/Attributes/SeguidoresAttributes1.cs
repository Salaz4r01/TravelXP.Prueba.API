

namespace TravelXP.Prueba.Infrastructure.DTO.DATA.Attributes
{
    internal class SeguidoresAttributes1
    {
        public int id { get; set; }
        public required int seguidor_id { get; set; }
        public required int seguido_id { get; set; }
        public required DateTime fecha_seguimiento { get; set; }
    }
}
