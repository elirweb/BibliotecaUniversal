using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimo.Application.ViewModel
{
    public class PedidoViewModel
    {
        public Guid Id { get;  set; }
        public Guid UsuarioId { get;  set; }
        public Guid BibliotecaId { get;  set; }
        public Guid LivroId { get;  set; }
        public DateTime DtPedido { get;  set; }
        public TimeSpan HoraPedido { get;  set; }

    }
}
