using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
           

            if (lv == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                    _livro.Adicionar(lv);
                    return Request.CreateResponse<UsuarioBiblioteca.Application.ViewModel.Livro>(HttpStatusCode.OK, lv);
                }
                catch (Exception ex)
                {
                  return  Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                }
            }
          
        }

        [HttpPost]
        [Route("update-livro")]
        public HttpResponseMessage UpdateLivro(UsuarioBiblioteca.Application.ViewModel.Livro lv)
        {
            if (lv == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro no acesso a Api ");
            else
            {
                try
                {
                   
                    _livro.UpdateLivro(lv);
                    return Request.CreateResponse(HttpStatusCode.OK, "Atualização feito com sucesso");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

                }
            }
           
        }

        [AcceptVerbs("GET")]
        [Route("ObterLivro")]
        public IEnumerable<UsuarioBiblioteca.Application.ViewModel.Livro> ObterLivro()
        {
           return  _livro.ObterLivro().ToList();
      
        }

        [AcceptVerbs("GET")]
        [Route("obterlivroid/{registro}")]
        public IEnumerable<UsuarioBiblioteca.Application.ViewModel.Livro> ObterLivroPorID(string registro)
        {
            return _livro.ObterLivroPorId(Guid.Parse(registro)).ToList();

        }
        [AcceptVerbs("GET")]
        [Route("delete-livro/{registro}")]
        public IEnumerable<UsuarioBiblioteca.Application.ViewModel.Livro> DeleteLivro(string registro)
        {
            return _livro.DeleteLivro(Guid.Parse(registro)).ToList();

        }

    }
}
