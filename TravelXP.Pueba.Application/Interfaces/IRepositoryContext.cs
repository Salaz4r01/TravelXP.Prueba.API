using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;
using TravelXP.Pueba.Application.Interfaces.Context;

namespace TravelXP.Pueba.Application.Interfaces
{
    public interface IRepositoryContext
    {
        public IComentarios_PublicacionContext Comentarios_PublicacionContext { get; }
        public ILikesContext LikesContext { get; }
        public IPublicacionesContext PublicacionContext { get; }
        public ISeguidoresContext SeguidoresContext { get; }
        public IUsuarioContext UsuarioContext { get; }
    }
}
