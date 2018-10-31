
using Biblioteca.Core.Domain.Validador.Interfaces;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using UsuarioBiblioteca.Application.ViewModel;
using UsuarioBiblioteca.Data.UnitOfWork;
using UsuarioBiblioteca.Domain.Interfaces.IRepositorios;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class LivroApp: Service.ApplicationServiceLv,Interfaces.ILivro
    {
        private readonly IRepositorioLivro repositorio;
        private readonly Log.Application.Interfaces.IRegistro reg;
        private HttpClient client;
        private HttpResponseMessage response;
        public LivroApp(IRepositorioLivro lv, IHandler<Domain.Especificacao.LivroDevePossuirUnicoTitulo> titulounico,
            IHandler<Domain.Especificacao.Livro_BibliotecaDeveEstarAtiva> bibliotecaativa, IUnitOfWork _unitOfWork,
            Log.Application.Interfaces.IRegistro log)
            :base(_unitOfWork,titulounico, bibliotecaativa)
        {
            repositorio = lv;
            reg = log;
        }

        //public void add(Livro lv, string token, out string retorno)
        //{
        //    var data = JsonConvert.SerializeObject(lv);
      
        //    retorno = string.Empty;

        //    using (client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["urlweb"]);
        //        client.DefaultRequestHeaders.Add("Bearer ", token);
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //        response = client.PostAsync("biblioteca/Cadastro/registrar-livro/", new StringContent(data, Encoding.UTF8, "application/json")).Result;
        //        var result = JsonConvert.SerializeObject(response.Content.ReadAsStringAsync().Result);
        //        if (response.StatusCode.Equals(HttpStatusCode.OK))
        //            retorno = "ok";
        //        else
        //            retorno = "erro";
        //    }

        //}

        public void Adicionar(ViewModel.Livro lv)
        {

            if (PossuiConformidade(new Domain.Validacao.LivroAptoParaCadastro(repositorio, reg)
                .Validar(Mapper.ViewModelToDomain.Livro(lv))))
            {
                if (lv.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    repositorio.Adicionar(Mapper.ViewModelToDomain.Livro(lv));
                    Commit();
                    Notificacao = null;
                }
            }

            if (Notificacao != null)
            {
                foreach (var erro in Notificacao)
                {
                    lv.ListaErros.Add(erro);
                }
            }
           
        }

        public void UpdateLivro(Livro lv)
        {
            throw new NotImplementedException();
        }
    }
}
