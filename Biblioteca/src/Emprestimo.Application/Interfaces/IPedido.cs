using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimo.Application.Interfaces
{
    public interface IPedido
    {
        void Adicionar(ViewModel.PedidoViewModel pv);
    }
}
