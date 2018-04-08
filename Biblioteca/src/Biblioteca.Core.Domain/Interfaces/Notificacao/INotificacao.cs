using Biblioteca.Core.Domain.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Interfaces.Notificacao
{
    public interface INotificacao
    {
        IList<object> Lista { get; }
        bool TemNotificacao { get; }

        bool Incluir(Descricao error);
        void Adicionar(Descricao error);
    }
}
