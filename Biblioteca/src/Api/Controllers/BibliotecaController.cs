using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using UsuarioBiblioteca.Application.Interfaces;

namespace Api.Controllers
{
    [RoutePrefix("biblioteca/Cadastro")]
    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 

    public class BibliotecaController : Controller
    {
        private readonly IBibliotecaria biblioteca;
        public BibliotecaController(IBibliotecaria bibli)
        {
            biblioteca = bibli;
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("registrar")]
        public HttpResponseMessage Registrar(UsuarioBiblioteca.Application.ViewModel.Bibliotecaria biblio) {
            var resposta = new HttpResponseMessage();

            if (biblio == null)
                return resposta.RequestMessage.CreateResponse(HttpStatusCode.BadRequest,"Erro no acesso a Api ");
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

        // GET: Biblioteca
        public ActionResult Index()
        {
            return View();
        }
    }
}