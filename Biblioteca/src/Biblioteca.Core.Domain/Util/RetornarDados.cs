using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Util
{
    public class RetornarDados
    {
        private HttpClient client = null;
        private HttpResponseMessage resp = new HttpResponseMessage();
        private string retorno = string.Empty;
        public async Task<T> GetDados<T>(string url, string token) where T : class, new()
        {
            try
            {
                using (client = new HttpClient())
                {

                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    resp = client.GetAsync(url).Result;
                    retorno = resp.Content.ReadAsStringAsync().Result;

                    if (resp.StatusCode != System.Net.HttpStatusCode.OK)
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

