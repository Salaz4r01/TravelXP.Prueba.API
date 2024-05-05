namespace TravelXP.Prueba.Domain.DTO.DATA.Attributes
{
    public class SeguidoresAttributes
    {
        public string result { get; set; }
        public int code { get; set; }
        public int id { get; set; }
        public required int seguidor_id { get; set; }
        public required int seguido_id { get; set; }
        public required DateTime fecha_seguimiento { get; set; }
    }
}
