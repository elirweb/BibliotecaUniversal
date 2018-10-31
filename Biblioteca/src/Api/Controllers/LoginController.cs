using Biblioteca.Core.Domain.Util;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using Usuario.Application.Interfaces;

namespace Api.Controllers
{
    [RoutePrefix("Usuario/Login")]
    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 
    
    public class LoginController : ApiController
    {
        private AuthenticarUsuario _util = new AuthenticarUsuario();
        private readonly IUsuario _usuarioapp;
        public LoginController(IUsuario usu) 
        {
            _usuarioapp = usu;
        }

        [AcceptVerbs("GET")]
        [Route("authenticar/{login}/{senha}")]
        public List<Authenticacao> Authenticacacao([FromUri]string login, [FromUri]string senha)
        {
            var usu = new Usuario.Application.ViewModel.Usuario()
            {
                Login = login,
                Senha = senha
            };

            var _accesstoken = new List<Authenticacao>();
            if (_usuarioapp.Authenticar(usu))
                _accesstoken = _util.Authenticar(ConfigurationManager.AppSettings["url_segura"], login, senha);
            if (_accesstoken.Count ==0)
                _accesstoken.Add(new Authenticacao { access_token = "Usuário ou senha inválido", token_type = "error" });

            return _accesstoken;
        }




    }
}
