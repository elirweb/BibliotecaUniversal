using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emprestimo.Domain.Entidade;

namespace Emprestimo.Data.Repositorio
{
    public class RepositorioPedido : Domain.Interfaces.Repositorio.IRepositorioPedido
    {
        private Contexto.Contexto contexto;
        public RepositorioPedido(Contexto.Contexto coc)
        {
            contexto = coc;
        }
        public void Adicionar(Pedido pe)
        {
            throw new NotImplementedException();
        }
    }
}
