using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using UsuarioBiblioteca.Application.Interfaces;

namespace Api.Controllers
{
    [Authorize(Roles = "biblioteca")]
    [RoutePrefix("Livro/Gestao")]
    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 

    public class LivroController : ApiController
    {
        private readonly ILivro _livro;
        public LivroController(ILivro lv)
        {
            _livro = lv;

        }

        [HttpPost]
        [Route("registrar-livro")]
        public HttpResponseMessage Livro(UsuarioBiblioteca.Application.ViewModel.Livro lv)
        {
            var resposta = new HttpResponseMessage();

            if (lv == null)
                resposta.RequestMessage.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    _livro.Adicionar(lv);
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
        [Route("update-livro")]
        public HttpResponseMessage UpdateLivro(UsuarioBiblioteca.Application.ViewModel.Livro lv)
        {
            var resposta = new HttpResponseMessage();

            if (lv == null)
                resposta.RequestMessage.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    _livro.UpdateLivro(lv);
                    resposta.RequestMessage.CreateResponse(HttpStatusCode.OK, "Atualização feito com sucesso");
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
