using Biblioteca.Core.Domain.Validador.Interfaces;
using System;
using UsuarioBiblioteca.Application.Handler;
using UsuarioBiblioteca.Application.Interfaces;
using UsuarioBiblioteca.Application.ViewModel;
using UsuarioBiblioteca.Data.UnitOfWork;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class BibliotecariaApp : Service.ApplicationServiceBiblio ,Interfaces.IBibliotecaria
    {
        private readonly Domain.Interfaces.IRepositorios.IRepositorioBibliotecaria repositorio;
        private readonly Log.Application.Interfaces.IRegistro reg;
        private readonly Biblioteca.Core.Domain.Util.DisposeElement _disposed = new Biblioteca.Core.Domain.Util.DisposeElement();
        public BibliotecariaApp(Domain.Interfaces.IRepositorios.IRepositorioBibliotecaria repo, Log.Application.Interfaces.IRegistro log,
            IUnitOfWork unitOfWork, IHandler<Domain.Especificacao.BibliotecaDevePossuiCNPJUnico> cnpjunico,
            IHandler<Domain.Especificacao.BibliotecaDevePossuirUnicoEmail> emailunico, IHandler<Domain.Especificacao.BibliotecaDevePossuirUnicoLogin> loginunico,
            BibliotecaCadastroHandler emailuser)
            :base(unitOfWork, cnpjunico, emailunico, loginunico,emailuser) 
        {
        
            repositorio = repo;
            reg = log;
        }

        public void Adicionar(Bibliotecaria bibli)
        {
            try
            {
                if (PossuiConformidade(new Domain.Validacao.BibliotecaAptoParaCadastro(repositorio, reg)
                .Validar(Mapper.ViewModelToDomain.Biblioteca(bibli))))
                {
                    if (bibli.Id != Guid.Parse(Biblioteca.Core.Domain.Util.UtilObject.guidobject))
                    {
                        repositorio.Adicionar(Mapper.ViewModelToDomain.Biblioteca(bibli));
                        Commit();
                        Notificacao = null;
                    }
                }

                if (Notificacao != null)
                {
                    foreach (var erro in Notificacao)
                    {
                        bibli.ListaErros.Add(erro);
                    }
                    Notificacao = null;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally {
                _disposed.Dispose();
            }
            
            
        }

        public void UpdateBiblioteca(Bibliotecaria update)
        {
            throw new NotImplementedException();
        }

        
    }
}
