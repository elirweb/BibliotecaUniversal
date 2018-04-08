using Biblioteca.Core.Domain.Validador;
using System;
using System.Linq;
using UsuarioBiblioteca.Application.ViewModel;
using UsuarioBiblioteca.Data.UnitOfWork;

namespace UsuarioBiblioteca.Application.AppActions
{
    public class BibliotecariaApp : Service.ApplicationService ,Interfaces.IBibliotecaria
    {
        private readonly UsuarioBiblioteca.Interfaces.IRepositorios.IRepositorioBibliotecaria reposi;
        public BibliotecariaApp(UsuarioBiblioteca.Interfaces.IRepositorios.IRepositorioBibliotecaria repo, IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            reposi = repo;
        }
        public Bibliotecaria Adicionar(Bibliotecaria biblio)
        {
            //if (PossuiConformidade(new 
              //  Validacao.BibliotecaAptoParaCadastro(reposi).Validate(Mapper.ViewModelToDomain.Biblioteca(biblio))));
            reposi.Adicionar(Mapper.ViewModelToDomain.Biblioteca(biblio));
            
            return biblio;
        }

        public bool PossuiConformidade(ValidacaoResultado validacao) {
            if (validacao == null) return true;
            /*
            var notifications = validacao.Erros.Select(validationError => new DomainNotification(validationError.ToString(), validationError.Message)).ToList();
            if (!notifications.Any()) return true;
            notifications.ToList().ForEach(DomainEvent.Raise);
            */        
    return false;
        }
    }
}
