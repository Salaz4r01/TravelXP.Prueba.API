using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelXP.Prueba.Domain.POCOS.Context
{
    public class EntityUsuarioContext
    {
        public required string result {  get; set; }
        public int code {  get; set; }
        public int id { get; set; }
        public required string nombre { get; set; }
        public required string apellido { get; set; }
        public required string nombre_usuario { get; set; }
        public required string email { get; set; }
        public required string contrasena { get; set; }
        public required string foto_perfil { get; set; }
        public required string biografia { get; set; }
        public required int rol { get; set; }
    }
}
