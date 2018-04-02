using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Usuario.Application.Interfaces;

namespace Api.Controllers
{
    [RoutePrefix("biblioteca/Login")]
    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 

    
   
    public class LoginController : ApiController
    {

        private readonly IUsuario usuarioapp;
        public LoginController(IUsuario usu) 
        {
            usuarioapp = usu;
        }

        [HttpGet]
        [Route("authenticar")]
        public HttpResponseMessage Authenticacacao([FromBody]Usuario.Application.ViewModel.Usuario usuario)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Usuario authenticado");
        }

       

        [AcceptVerbs("GET")]
        [Route("recuperarsenha")]

        public HttpResponseMessage RecuperarSenha() {
            return Request.CreateResponse(HttpStatusCode.OK,"elirweb@gmail.com");
            
        }
    }
}
