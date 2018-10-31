using Biblioteca.Core.Domain.Util;
using Biblioteca.Core.Domain.ValueObjects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;


namespace Api.Controllers
{
    [RoutePrefix("Adm/LoginAdm")]
    [EnableCors(origins: "*", headers: "*", methods: "*")] // definindo o cabecalho de origens para receber metodo get 

    public class LoginBibliotecaController : ApiController
    {
        private Biblioteca.Core.Domain.Util.AuthenticarUsuario _util = new AuthenticarUsuario();
        private readonly UsuarioBiblioteca.Application.Interfaces.IAdministrador admapp;
        public LoginBibliotecaController(UsuarioBiblioteca.Application.Interfaces.IAdministrador a)
        {
            admapp = a;
        }

        [AcceptVerbs("GET")]
        [Route("authenticar/{login}/{senha}")]
        public List<Authenticacao> Authenticacacao([FromUri]string login, [FromUri]string senha)
        {
            var b = new UsuarioBiblioteca.Application.ViewModel.Administrador()
            {
                Login = login,
                Senha = senha
            };
            var _accesstoken = new List<Authenticacao>();
            if (admapp.Authenticar(b))
                _accesstoken = _util.Authenticar(ConfigurationManager.AppSettings["url_segura"], login, senha);
            if (_accesstoken.Count == 0)
                _accesstoken.Add(new Authenticacao { access_token = "Usuário ou senha inválido", token_type = "error" });
            
            return _accesstoken;


        }

    }
}

   