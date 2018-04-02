using Biblioteca.Core.Domain.Events;
using Biblioteca.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Data.UnitOfWork;
using UsuarioBiblioteca.Handler;

namespace UsuarioBiblioteca.Application.Service
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IHandler<DomainNotification> Notifications;
        protected readonly Handler.BibliotecaCadastroHandler Biblioteca;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            //this.Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
            //Biblioteca = DomainEvent.Container.GetInstance<Handler.BibliotecaCadastroHandler>();
        }

        public bool Commit()
        {
            if (Notifications.HasNotifications())
                return false;
            _unitOfWork.Commit();
            return true;
        }
    }
}

