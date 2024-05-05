using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO;
using TravelXP.Pueba.Application.Interfaces.Presenter;
using TravelXP.Pueba.Application.Presenters;
using static TravelXP.Pueba.Application.Presenters.Comentarios_publicacionLogic;

namespace TravelXP.Pueba.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IComentarios_PublicacionPresenter, ComentariosPublicacionLogic>();
            //services.AddScoped<ILikesPresenter, LikesLogic>();
            //services.AddScoped<IPublicacionesPresenter, PublicacionesLogic>();
            //services.AddScoped<ISeguidoresPresenter, SeguidoresLogic>();
            //services.AddScoped<IUsuarioPresenter, UsuarioLogic>();
            return services;
        }
    }
}
