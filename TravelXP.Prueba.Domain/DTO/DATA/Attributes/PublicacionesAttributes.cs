namespace TravelXP.Prueba.Domain.DTO.DATA.Attributes
{
    public class PublicacionesAttributes
    {
        public string result { get; set; }
        public int code { get; set; }
        public required int publicacion_id { get; set; }
        public required int usuario_id { get; set; }
        public required DateTime fecha { get; set; }
        public string? imagen { get; set; }
        public string? descripcion { get; set; }
        public required string? tipo_publicacion { get; set; }
        public required string? ubicacion { get; set; }
    }
}
