using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimo.Domain.Entidade
{
    public class Pedido
    {
        public Guid Id { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Guid BibliotecaId { get; private set; }
        public Guid LivroId { get; private set; }
        public DateTime DtPedido { get; private set; }
        public TimeSpan HoraPedido { get; private set; }

        public Pedido(Guid id, Guid  idusuario,Guid biliotecaid, Guid livroid)
        {
            Id = id;
            UsuarioId = idusuario;
            BibliotecaId = BibliotecaId;
            LivroId = livroid;
            DtPedido = DateTime.Now.Date;
            HoraPedido = TimeSpan.FromHours(1);
        }

       
    }
}
