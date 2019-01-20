using Emprestimo.Application.ViewModel;
using Emprestimo.Domain.Interfaces.Repositorio;

namespace Emprestimo.Application.AppAction
{
    public class Pedido : Interfaces.IPedido
    {

        private readonly IRepositorioPedido _repositorio;

        public Pedido(IRepositorioPedido ped)
        {
            _repositorio = ped;
        }
        public void Adicionar(PedidoViewModel pv)
        {
            _repositorio.Adicionar(Mapper.ViewModelToDomain.Pedido(pv));
        }
    }
}
