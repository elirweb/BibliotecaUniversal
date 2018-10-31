using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using UsuarioBiblioteca.Application.Interfaces;

namespace Api.Controllers
{
    [Authorize(Roles = "biblioteca")]
    [RoutePrefix("biblioteca/Gestao")]
    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 

    public class BibliotecaController : ApiController
    {

        private readonly IBibliotecaria biblioteca;
        private readonly IEndereco endereco;
       
        public BibliotecaController(IBibliotecaria bibli, IEndereco end)
        {
            biblioteca = bibli;
            endereco = end;
            
        }

        [HttpPost]
        [Route("registrar-biblioteca")]
        public HttpResponseMessage Registrar(UsuarioBiblioteca.Application.ViewModel.Bibliotecaria biblio)
        {
            var resposta = new HttpResponseMessage();

            if (biblio == null)
                 resposta.RequestMessage.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    biblioteca.Adicionar(biblio);
                     resposta.RequestMessage.CreateResponse(HttpStatusCode.OK, "Cadastro feito com sucesso");
                }
                catch (Exception ex)
                {
                     resposta.RequestMessage.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                }
            }
            return resposta;   
        }

        [HttpPost]
        [Route("registrar-endereco")]
        public HttpResponseMessage Endereco(UsuarioBiblioteca.Application.ViewModel.Endereco end)
        {
            var resposta = new HttpResponseMessage();

            if (end == null)
                 resposta.RequestMessage.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    endereco.Adicionar(end);
                    resposta.RequestMessage.CreateResponse(HttpStatusCode.OK, "Cadastro feito com sucesso");
                }
                catch (Exception ex)
                {

                    resposta.RequestMessage.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            return resposta;
        }

        
        
        [HttpPut]
        [Route("update-biblioteca")]
        public HttpResponseMessage UpdateBiblioteca(UsuarioBiblioteca.Application.ViewModel.Bibliotecaria b)
        {
            var resposta = new HttpResponseMessage();

            if (b == null)
                resposta.RequestMessage.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    biblioteca.UpdateBiblioteca(b);
                    resposta.RequestMessage.CreateResponse(HttpStatusCode.OK, "Atualizacao feito com sucesso");
                }
                catch (Exception ex)
                {
                    resposta.RequestMessage.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                }
            }
            return resposta;
        }

        [HttpPut]
        [Route("update-endereco")]
        public HttpResponseMessage UpdateEndereco(UsuarioBiblioteca.Application.ViewModel.Endereco end)
        {
            var resposta = new HttpResponseMessage();

            if (end == null)
                resposta.RequestMessage.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    endereco.UpdateEndereco(end);
                    resposta.RequestMessage.CreateResponse(HttpStatusCode.OK, "Atualizacao feito com sucesso");
                }
                catch (Exception ex)
                {
                    resposta.RequestMessage.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                }
            }
            return resposta;
        }
    }

}