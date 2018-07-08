using Newtonsoft.Json;
using System;
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

        public void Add(Endereco end, Bibliotecaria bi, string token)
        {
            var data = JsonConvert.SerializeObject(bi);
            var dta = JsonConvert.SerializeObject(end);
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("");
                client.DefaultRequestHeaders.Add("Bearer ", token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                response = client.PostAsync("", new StringContent(data, Encoding.UTF8, "application/json")).Result;
                var result = JsonConvert.SerializeObject(response.Content.ReadAsStringAsync().Result);
                if (response.StatusCode.Equals(HttpStatusCode.OK)) 
                    resp2 = client.PostAsync("", new StringContent(dta, Encoding.UTF8, "application/json")).Result;

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
