using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emprestimo.Domain.Mapping
{
    public class Pedido : EntityTypeConfiguration<Entidade.Pedido>
    {
        public Pedido()
        {
            ToTable("Pedido");
            HasKey(c=>c.Id);
            Property(c=>c.DtPedido).HasColumnType("Datetime");
            Property(c => c.HoraPedido).HasColumnType("times");
            Property(c => c.LivroId);
            Property(c => c.UsuarioId);
            Property(c => c.BibliotecaId);

        }
    }
}
