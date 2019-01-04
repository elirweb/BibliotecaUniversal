using Biblioteca.Core.Domain.Validador.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UsuarioBiblioteca.Data.UnitOfWork;

namespace UsuarioBiblioteca.Application.Service
{
    public class ApplicationServiceLv
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IHandler<Domain.Especificacao.LivroDevePossuirUnicoTitulo> titulounico;
        private readonly IHandler<Domain.Especificacao.Livro_BibliotecaDeveEstarAtiva> bibliotecaativa;
        public static IEnumerable<string> Notificacao;

        public ApplicationServiceLv(IUnitOfWork unitOfWork, IHandler<Domain.Especificacao.LivroDevePossuirUnicoTitulo> titulo,
            IHandler<Domain.Especificacao.Livro_BibliotecaDeveEstarAtiva> bibli)
        {
            _unitOfWork = unitOfWork;
            titulounico = titulo;
            bibliotecaativa = bibli;
        }
        public bool Commit()
        {
         _unitOfWork.Commit();
         return true;
            
        }

        public static bool PossuiConformidade(Domain.Entidades.Livro lv)
        {
            if (lv.ValidacaoResultado.Erros.Count == 0) return true;
            Notificacao = lv.ValidacaoResultado.Erros.
                Select(c => c.Menssage);
            if (!Notificacao.Any())
                return true;
            return false;
        }
    }
}
