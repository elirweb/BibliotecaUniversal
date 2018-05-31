using Biblioteca.Core.Domain.Validador.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UsuarioBiblioteca.Data.UnitOfWork;

namespace UsuarioBiblioteca.Application.Service
{
    public class ApplicationServiceAdm
    {
        private readonly IUnitOfWork _unitOfWork;
    
        private readonly IHandler<Domain.Especificacao.AdministradorDevePossuirUnicoLogin> especificaoadm;
        public static IEnumerable<string> Notificacao;

        public ApplicationServiceAdm(IUnitOfWork unitOfWork, IHandler<Domain.Especificacao.AdministradorDevePossuirUnicoLogin> loginunico)
        {
            this._unitOfWork = unitOfWork;
            especificaoadm = loginunico;
        }

        public bool Commit()
        {
            if (especificaoadm.EhValido())
            {
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public static bool PossuiConformidade(Domain.Entidades.Administradores adm)
        {
            if (adm.ValidacaoResultado.Erros.Count == 0) return true;
            Notificacao = adm.ValidacaoResultado.Erros.
                Select(c => c.Menssage);
            if (!Notificacao.Any())
                return true;
            return false;
        }
    }
}

