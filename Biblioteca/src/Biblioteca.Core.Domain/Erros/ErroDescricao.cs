
using Biblioteca.Core.Domain.Interfaces.Erros;
using Biblioteca.Core.Domain.Notificacao;

namespace Biblioteca.Core.Domain.Erros
{
    public class ErroDescricao : Descricao
    {
        public INivel Nivel { get; }

        public ErroDescricao(string message, INivel nivel, params string[] args)
            : base(message, args)
        {
            Nivel = nivel;
        }
    }
}
