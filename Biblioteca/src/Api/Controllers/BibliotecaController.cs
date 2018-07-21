using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using UsuarioBiblioteca.Application.Interfaces;

namespace Api.Controllers
{
    [Authorize(Roles = "biblioteca")]
    [RoutePrefix("biblioteca/Cadastro")]
    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 

    public class BibliotecaController : ApiController
    {

        private readonly IBibliotecaria biblioteca;
        private readonly IEndereco endereco;
        private readonly ILivro livro; 

        public BibliotecaController(IBibliotecaria bibli, IEndereco end, ILivro lv)
        {
            biblioteca = bibli;
            endereco = end;
            livro = lv;
        }

        [HttpPost]
        [Route("registrar-biblioteca")]
        public HttpResponseMessage Registrar(UsuarioBiblioteca.Application.ViewModel.Bibliotecaria biblio)
        {
            var resposta = new HttpResponseMessage();

            if (biblio == null)
                return resposta.RequestMessage.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    biblioteca.Adicionar(biblio);
                    resposta.RequestMessage.CreateResponse(HttpStatusCode.OK, "Cadastro feito com sucesso");
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
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
                return resposta.RequestMessage.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    endereco.Adicionar(end);
                    resposta.RequestMessage.CreateResponse(HttpStatusCode.OK, "Cadastro feito com sucesso");
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            return resposta;
        }

        [HttpPost]
        [Route("registrar-livro")]
        public HttpResponseMessage Livro(UsuarioBiblioteca.Application.ViewModel.Livro lv) {
            var resposta = new HttpResponseMessage();

            if (lv == null)
                return resposta.RequestMessage.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    livro.Adicionar(lv);
                    resposta.RequestMessage.CreateResponse(HttpStatusCode.OK, "Cadastro feito com sucesso");
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            return resposta;
        }
        
        

    }

}