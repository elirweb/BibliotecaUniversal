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
        public EnderecoApp(IRepositorioEndereco end, IUnitOfWork unitOfWork, BibliotecaCadastroHandler emailuser) :base(unitOfWork, emailuser)
        {
            repositorio = end;
        }

        

        public void Adicionar(Endereco endereco)
        {
            repositorio.Adicionar(Mapper.ViewModelToDomain.Endereco(endereco));
            Commit();
            emailuser.SejaBemVindo("elirweb@gmail.com", endereco.Id.ToString(), "Portal Biblioteca Universal", "Olá " + endereco.Id+ " Sejá bem vindo ao maior portal da américa latina");

        }

    
    }
}
