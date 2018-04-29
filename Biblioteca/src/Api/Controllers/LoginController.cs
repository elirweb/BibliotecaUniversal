﻿using Biblioteca.Core.Domain.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        [AcceptVerbs("GET")]
        [Route("authenticar/{login}/{senha}")]
        public List<Authenticacao> Authenticacacao([FromUri]string login,[FromUri]string senha)
        {
            var usu = new Usuario.Application.ViewModel.Usuario() {
                Login = login,
                Senha = senha
            };
            HttpClient client = null;
            HttpResponseMessage resp = new HttpResponseMessage();
            var retorno = string.Empty;
            var _accesstoken = new List<Authenticacao>();
            if (usuarioapp.Authenticar(usu))
            {
                
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:10078/");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    resp = client.PostAsync("api/security/token", new StringContent("grant_type=password&username=" + usu.Login + "&password=" + usu.Senha, Encoding.UTF8, "application/json")).Result;
                    retorno = resp.Content.ReadAsStringAsync().Result;
                    if (resp.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        JArray token = JArray.Parse("[" + retorno + "]");
                        foreach (JObject obj in token.Children<JObject>())
                            _accesstoken.Add(new Authenticacao { access_token = obj.SelectToken("access_token").ToString(),
                                expires_in = obj.SelectToken("expires_in").ToString(),
                                token_type = obj.SelectToken("token_type").ToString(),
                                Login = login });
                    }
                    
                }
            }
            else
                _accesstoken.Add(new Authenticacao { access_token = "Usuário ou senha inválido", token_type = "error" });

            return _accesstoken;

        }

      

        [AcceptVerbs("GET")]
        [Route("recuperarsenha")]

        public HttpResponseMessage RecuperarSenha() {
            return Request.CreateResponse(HttpStatusCode.OK,"elirweb@gmail.com");
            
        }
    }
}
