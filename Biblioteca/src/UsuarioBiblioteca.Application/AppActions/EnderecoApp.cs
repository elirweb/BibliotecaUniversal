using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using UsuarioBiblioteca.Application.Handler;
using UsuarioBiblioteca.Application.ViewModel;
using UsuarioBiblioteca.Data.UnitOfWork;
using UsuarioBiblioteca.Domain.Interfaces.IRepositorios;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class EnderecoApp : Service.AplicationServiceEnd, Interfaces.IEndereco
    {
        private readonly IRepositorioEndereco repositorio;
        private HttpClient client = null;
        private HttpResponseMessage response = null;
        private HttpResponseMessage resp2 = null;
        public EnderecoApp(IRepositorioEndereco end, IUnitOfWork unitOfWork, BibliotecaCadastroHandler emailuser) :base(unitOfWork, emailuser)
        {
            repositorio = end;
        }

        public void Add(Endereco end, Bibliotecaria bi, string token,out string retorno)
        {
            var data = JsonConvert.SerializeObject(bi);
            var dta = JsonConvert.SerializeObject(end);
            retorno = string.Empty;

            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["urlweb"]);
                client.DefaultRequestHeaders.Add("Bearer ", token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                response = client.PostAsync("biblioteca/Cadastro/registrar-biblioteca/", new StringContent(data, Encoding.UTF8, "application/json")).Result;
                var result = JsonConvert.SerializeObject(response.Content.ReadAsStringAsync().Result);
                if (response.StatusCode.Equals(HttpStatusCode.OK)) 
                    resp2 = client.PostAsync("biblioteca/Cadastro/registrar-endereco/", new StringContent(dta, Encoding.UTF8, "application/json")).Result;

                if (resp2.StatusCode.Equals(HttpStatusCode.OK) && response.StatusCode.Equals(HttpStatusCode.OK))
                    retorno = "ok";
                else
                    retorno = "erro";
            }

        }

        public void Adicionar(Endereco endereco)
        {
            repositorio.Adicionar(Mapper.ViewModelToDomain.Endereco(endereco));
            Commit();
            emailuser.SejaBemVindo("elirweb@gmail.com", endereco.Id.ToString(), "Portal Biblioteca Universal", "Olá " + endereco.Id+ " Sejá bem vindo ao maior portal da américa latina");

        }
    }
}
