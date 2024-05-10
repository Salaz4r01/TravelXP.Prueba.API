using Microsoft.Extensions.Configuration;
using MySqlConnectionExample;
using TravelXP.Prueba.Infrastructure.Context;
using TravelXP.Pueba.Application.Interfaces;
using TravelXP.Pueba.Application.Interfaces.Context;

namespace TravelXP.Prueba.Infrastructure.Repository
{
    public class RepositoryContext : IRepositoryContext
    {
        public readonly BDServices _bd;

        public RepositoryContext(IConfiguration configuration)
        {
            _bd = new BDServices(configuration);
        }
        public IComentarios_PublicacionContext Comentarios_PublicacionContext => new Comentarios_PublicacionContext(_bd);
        public ILikesContext LikesContext => new LikesContext(_bd);
        public IPublicacionesContext PublicacionContext => new PublicacionesContext(_bd);
        public ISeguidoresContext SeguidoresContext => new SeguidoresContext(_bd);
        public IUsuarioContext UsuarioContext => new UsuarioContext(_bd);
    }
}
