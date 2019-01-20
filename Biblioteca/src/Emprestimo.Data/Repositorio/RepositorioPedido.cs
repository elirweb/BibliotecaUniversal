using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emprestimo.Domain.Entidade;

namespace Emprestimo.Data.Repositorio
{
    public class RepositorioPedido : Biblioteca.Core.Domain.Util.DisposeElement, Domain.Interfaces.Repositorio.IRepositorioPedido
    {
        private Contexto.Contexto _contexto;
        public RepositorioPedido(Contexto.Contexto coc)
        {
            _contexto = coc;
        }
        public void Adicionar(Pedido pe)
        {
            _contexto.Pedido.Add(pe);
        }
    }
}
