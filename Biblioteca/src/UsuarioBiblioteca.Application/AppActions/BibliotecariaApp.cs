using Biblioteca.Core.Domain.Validador.Interfaces;
using System;
using UsuarioBiblioteca.Application.Handler;
using UsuarioBiblioteca.Application.ViewModel;
using UsuarioBiblioteca.Data.UnitOfWork;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class BibliotecariaApp : Service.ApplicationServiceBiblio ,Interfaces.IBibliotecaria
    {
        private readonly Domain.Interfaces.IRepositorios.IRepositorioBibliotecaria repositorio;
        private readonly Log.Application.Interfaces.IRegistro reg;
        public BibliotecariaApp(Domain.Interfaces.IRepositorios.IRepositorioBibliotecaria repo, Log.Application.Interfaces.IRegistro log,
            IUnitOfWork unitOfWork, IHandler<Domain.Especificacao.BibliotecaDevePossuiCNPJUnico> cnpjunico,
            IHandler<Domain.Especificacao.BibliotecaDevePossuirUnicoEmail> emailunico, IHandler<Domain.Especificacao.BibliotecaDevePossuirUnicoLogin> loginunico,
            BibliotecaCadastroHandler emailuser)
            :base(unitOfWork, cnpjunico, emailunico, loginunico,emailuser) 
        {
        
            repositorio = repo;
            reg = log;
        }

        public ViewModel.Bibliotecaria Adicionar(ViewModel.Bibliotecaria bibli)
        {

            if (PossuiConformidade(new Domain.Validacao.BibliotecaAptoParaCadastro(repositorio, reg)
                .Validar(Mapper.ViewModelToDomain.Biblioteca(bibli))))
            {
                if (bibli.Id != Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    repositorio.Adicionar(Mapper.ViewModelToDomain.Biblioteca(bibli));
                    Commit();
                }
            }

            if (Notificacao != null)
            {
                foreach (var erro in Notificacao)
                {
                    bibli.ListaErros.Add(erro);
                }
            }
            return bibli;
        }

       
    }
}
