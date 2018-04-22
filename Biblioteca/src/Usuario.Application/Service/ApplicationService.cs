using Biblioteca.Core.Domain.Validador.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Usuario.Application.Handler;
using Usuario.Data.UnitOfWork;

namespace Usuario.Application.Service
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHandler<Domain.Especificacao.UsuarioDevePossuirUnicoCPF> especificaousuario;
        public static IEnumerable<string> Notificacao;
        public UsuarioCadastroHandler usuariohandler;
         
        public ApplicationService(IUnitOfWork unitOfWork,
            IHandler<Domain.Especificacao.UsuarioDevePossuirUnicoCPF> cpf, UsuarioCadastroHandler emailuse)
        {
            _unitOfWork = unitOfWork;
            especificaousuario = cpf;
            usuariohandler = emailuse;
            
        }

        public bool Commit()
        {
            if (especificaousuario.EhValido())
            {
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public static bool PossuiConformidade(Domain.Entidade.Usuario usuario)
        {
            if (usuario.ValidacaoResultado.Erros.Count == 0) return true;
            Notificacao = usuario.ValidacaoResultado.Erros.
                Select(c => c.Menssage);
            if (!Notificacao.Any())
                return true;
            return false;
        }

       
    }
}

