using Biblioteca.Core.Domain.Interfaces.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Domain.Notificacao
{
    public abstract class ListaNotificacao : INotificacao
    {
        public IList<object> Lista { get; } = new List<object>();
        public bool TemNotificacao => Lista.Any();

        public bool Incluir(Descricao error)
        {
            return Lista.Contains(error);
        }

        public void Adicionar(Descricao description)
        {
            Lista.Add(description);
        }
    }
}
