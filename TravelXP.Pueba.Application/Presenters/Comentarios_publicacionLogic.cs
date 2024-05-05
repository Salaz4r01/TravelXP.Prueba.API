using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelXP.Prueba.Domain.DTO.DATA.Attributes;
using TravelXP.Prueba.Domain.DTO.DATA;
using TravelXP.Prueba.Domain.DTO.Response;
using TravelXP.Prueba.Domain.POCOS.Context;
using TravelXP.Pueba.Application.Interfaces.Presenter;
using TravelXP.Pueba.Application.Interfaces;
using TravelXP.Prueba.Domain.DTO.Request.Permisos;

namespace TravelXP.Pueba.Application.Presenters
{
    public class Comentarios_publicacionLogic
    {
        public class ComentariosPublicacionLogic : IComentarios_PublicacionPresenter
        {
            public List<string> _error { get; set; }
            public ErrorResponse _errorResponse { get; set; }

            private readonly IRepositoryContext _comentariosRepository;

            public ComentariosPublicacionLogic(IRepositoryContext comentariosRepository)
            {
                _error = new List<string>();
                _errorResponse = new ErrorResponse();
                _comentariosRepository = comentariosRepository;
            }

            public async Task<Comentarios_PublicacionData> Comentarios_Publicacion_GETAsync(string contenido)
            {
                if (contenido == "")
                {
                    return null;
                }
                if (contenido == "")
                {
                    _error.Add("La publicacion debe tener 1 caracter");
                    return null;
                }
                List<Comentarios_PublicacionAttributes> comentariosAttributes = new();

                var result = await _comentariosRepository.Comentarios_PublicacionContext.Get(contenido); 

                List<EntityComentarios_PublicacionContext> comentarios = result.ToList();
                if (comentarios.Count > 0 && comentarios[0].code == 200)
                {
                    List<Comentarios_PublicacionAttributes> comentarios1 = new();
                    foreach (var comentariosA in comentarios)
                    {
                        comentarios1.Add(new Comentarios_PublicacionAttributes
                        {
                            id = comentariosA.id,
                            publicacion_id = comentariosA.publicacion_id,
                            usuario_id = comentariosA.usuario_id,
                            contenido = comentariosA.contenido,
                            fecha = (DateTime)comentariosA.fecha,
                        });
                    }

                }
                return new Comentarios_PublicacionData();
                {
                    //Type = "comentarios",
                    //attributes = Comentarios_PublicacionAttributes // Dudaa
                }
            }


            // POST
            public async ValueTask<Comentarios_PublicacionResponse> Post(string contenido)
            {
                var comentarios = await _comentariosRepository.Comentarios_PublicacionContext.Post(contenido);
                if (comentarios.code == 200)
                    return new Comentarios_PublicacionResponse() { data = new Comentarios_PublicacionData() { attributes = new Comentarios_PublicacionAttributes() { result = comentarios.result }, type = "comentarios" } };
                _errorResponse.errors = new List<ErrorData>() { new ErrorData() { code = comentarios.code.ToString(), detail = comentarios.result, status = comentarios.code, title = "todo se derrumbó" } };
                return null;


            }
            //PATCH
            public async Task<Comentarios_PublicacionResponse> Update(string contenido)
            {     
                var updatedItem = await _comentariosRepository.Comentarios_PublicacionContext.Update(contenido);

                var response = new Comentarios_PublicacionResponse();

                response.data = new Comentarios_PublicacionData(){ attributes = new Comentarios_PublicacionAttributes() { result = updatedItem.result } };
                response.data = new Comentarios_PublicacionData() { attributes = new Comentarios_PublicacionAttributes() { code = updatedItem.code } };
                return response;
            }
            //DELETE
            public async Task<Comentarios_PublicacionResponse2> Delete(int id)
            {
                var result = await _comentariosRepository.Comentarios_PublicacionContext.Delete(id);

                Comentarios_PublicacionData2 responseData;

                if (result != null && result.code == 200)
                {
                    responseData = new Comentarios_PublicacionData2
                    {
                        type = "comentario", // Tipo de comentario (puede ser constante o extraído de result)
                        attributes2 = new Comentarios_PublicacionAttributes2
                        {
                               result = result.result,
                               code = result.code,
                        }
                    };
                }
                else
                {
                    // Si no hay datos relevantes en result, puedes asignar valores predeterminados o nulos.
                    responseData = new Comentarios_PublicacionData2
                    {
                        type = null,
                        attributes2 = new Comentarios_PublicacionAttributes2
                        {
                        }
                    };
                }

                return new Comentarios_PublicacionResponse2
                {
                    data2 = responseData
                };
            }

        }
    }
}