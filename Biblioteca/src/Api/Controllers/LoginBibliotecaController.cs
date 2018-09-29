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
            if (_accesstoken == null)
                _accesstoken.Add(new Authenticacao { access_token = "Usuário ou senha inválido", token_type = "error" });

            return _accesstoken;


        }

    }
}

    /*
       using (client = new HttpClient())
                {

                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["url_segura"]);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    resp = client.PostAsync("api/security/token", new StringContent("grant_type=password&username=" + b.Login + "&password=" + b.Senha, Encoding.UTF8, "application/json")).Result;
                    retorno = resp.Content.ReadAsStringAsync().Result;
                    if (resp.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        JArray token = JArray.Parse("[" + retorno + "]");
                        foreach (JObject obj in token.Children<JObject>())
                            _accesstoken.Add(new Authenticacao
                            {
                                access_token = obj.SelectToken("access_token").ToString(),
                                expires_in = obj.SelectToken("expires_in").ToString(),
                                token_type = obj.SelectToken("token_type").ToString(),
                                Login = login
                            });
                    }
                }
            }
            else
                _accesstoken.Add(new Authenticacao { access_token = "Usuário ou senha inválido", token_type = "error" });

            return _accesstoken;

        }
     */
       