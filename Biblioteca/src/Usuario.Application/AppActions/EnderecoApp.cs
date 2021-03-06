﻿using Biblioteca.Core.Domain.Validador.Interfaces;
using Usuario.Application.Handler;
using Usuario.Application.ViewModel;
using Usuario.Data.UnitOfWork;
using Usuario.Domain.Interfaces.Repositorios;

namespace Usuario.Application.AppActions
{
    public class EnderecoApp : Service.AplicationServiceEnd, Interfaces.IEndereco
    {
        private readonly IRepositorioEndereco repositorio;

        public EnderecoApp(IRepositorioEndereco end, IUnitOfWork unitOfWork,
             UsuarioCadastroHandler usuhandler) 
            : base(unitOfWork, usuhandler)
        {
            repositorio = end;
        }


        public void Adicionar(EnderecoUsuario endereco)
        {
            repositorio.Adicionar(Mapper.VewModelToDomain.Endereco(endereco));
            Commit();
            usuariohandler.SejaBemVindo("elirweb@gmail.com", endereco.IdUsuario.Nome, "Portal Biblioteca Universal", "Olá "+ endereco.IdUsuario.Nome + " Sejá bem vindo ao maior portal da américa latina");

        }
    }
}
