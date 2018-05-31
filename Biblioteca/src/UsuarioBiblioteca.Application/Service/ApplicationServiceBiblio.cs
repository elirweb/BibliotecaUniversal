using Biblioteca.Core.Domain.Validador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioBiblioteca.Application.Handler;
using UsuarioBiblioteca.Data.UnitOfWork;

namespace UsuarioBiblioteca.Application.Service
{
    public class ApplicationServiceBiblio
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHandler<Domain.Especificacao.BibliotecaDevePossuiCNPJUnico> cnpjunico;
        private readonly IHandler<Domain.Especificacao.BibliotecaDevePossuirUnicoEmail> emailunico;
        private readonly IHandler<Domain.Especificacao.BibliotecaDevePossuirUnicoLogin> loginunico;
        public BibliotecaCadastroHandler emailbiblio;

        public static IEnumerable<string> Notificacao;

        public ApplicationServiceBiblio(IUnitOfWork unitOfWork, IHandler<Domain.Especificacao.BibliotecaDevePossuiCNPJUnico> cnpj,
            IHandler<Domain.Especificacao.BibliotecaDevePossuirUnicoEmail> email,
            IHandler<Domain.Especificacao.BibliotecaDevePossuirUnicoLogin> login,
            BibliotecaCadastroHandler emailuser
            )
        {
            this._unitOfWork = unitOfWork;
            cnpjunico = cnpj;
            emailunico = email;
            loginunico = login;
            emailbiblio = emailuser;
        }

        public bool Commit()
        {
            if (cnpjunico.EhValido() && emailunico.EhValido() && loginunico.EhValido())
            {
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public static bool PossuiConformidade(Domain.Entidades.Bibliotecaria bibli)
        {
            if (bibli.ValidacaoResultado.Erros.Count == 0) return true;
            Notificacao = bibli.ValidacaoResultado.Erros.
                Select(c => c.Menssage);
            if (!Notificacao.Any())
                return true;
            return false;
        }
    }
}


