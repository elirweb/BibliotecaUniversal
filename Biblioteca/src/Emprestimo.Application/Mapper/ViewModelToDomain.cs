using System;

namespace Emprestimo.Application.Mapper
{
    public static class ViewModelToDomain
    {
        public static Domain.Entidade.Pedido Pedido(ViewModel.PedidoViewModel p) {
            if (p == null) throw new Exception();
            return new Domain.Entidade.Pedido(p.Id,p.UsuarioId,p.BibliotecaId, p.LivroId);
           
        }
    }
}
