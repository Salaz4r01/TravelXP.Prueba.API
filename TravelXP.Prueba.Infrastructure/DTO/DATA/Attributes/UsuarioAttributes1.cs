namespace TravelXP.Prueba.Domain.DTO.DATA.Attributes
{
    public class UsuarioAttributes1
    {
        public int id { get; set; }
        public required string nombre { get; set; }
        public required string apellido { get; set; }
        public required string nombre_usuario { get; set; }
        public required string email { get; set; }
        public required string contrasena { get; set; }
        public required string? foto_perfil { get; set; }
        public required string? biografia { get; set; }
        public required int rol { get; set; }
    }
}
