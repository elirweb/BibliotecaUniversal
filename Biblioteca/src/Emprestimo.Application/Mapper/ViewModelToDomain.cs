using System;

namespace Emprestimo.Application.Mapper
{
    public static class ViewModelToDomain
    {
        public static Domain.Entidade.Pedido Pedido(ViewModel.PedidoViewModel p) {
            if (p == null) throw new Exception();
            return new Domain.Entidade.Pedido( p.LivroId,p.UsuarioId,p.BibliotecaId);
           
        }
    }
}
