using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Util
{
    public class AuthenticarUsuario
    {
        private HttpClient client = null;
        private HttpResponseMessage resp = new HttpResponseMessage();
        private string retorno = string.Empty;

        public List<Authenticacao> Authenticar(string url, string login, string senha)
        {
            var _accesstoken = new List<Authenticacao>();

            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                resp = client.PostAsync("api/security/token", new StringContent("grant_type=password&username=" + login + "&password=" + senha, Encoding.UTF8, "application/json")).Result;
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
            return _accesstoken;

        }



    }
}