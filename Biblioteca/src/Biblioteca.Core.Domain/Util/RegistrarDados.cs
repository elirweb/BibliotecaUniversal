using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Util
{
    public class RegistrarDados
    {
        private HttpClient client = null;
        private HttpResponseMessage resp = new HttpResponseMessage();
        private string retorno = string.Empty;
        public async Task<T> PostDados<T>(string url, string token, object dados)where T: class,new() {
            try
            {
                string conteudo = JsonConvert.SerializeObject(dados);
                using (client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                    resp =  client.PostAsync(url, new StringContent(conteudo,Encoding.UTF8, "application/json")).Result;
                    retorno = resp.Content.ReadAsStringAsync().Result;

                    if(resp.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return new T();

                    }
                    return JsonConvert.DeserializeObject<T>(retorno);
                }

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
