using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emprestimo.Application.ViewModel;
using Emprestimo.Domain.Interfaces.Repositorio;

namespace Emprestimo.Application.AppAction
{
    public class Pedido : Interfaces.IPedido
    {

        private readonly IRepositorioPedido repositorio;

        public Pedido(IRepositorioPedido ped)
        {
            repositorio = ped;
        }
        public void Adicionar(PedidoViewModel pv)
        {
            throw new NotImplementedException();
        }
    }
}
