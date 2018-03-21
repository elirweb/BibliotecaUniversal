using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Domain.Mapping
{
    public class Registro: EntityTypeConfiguration<Entidade.Registro>
    {
        public Registro()
        {
            ToTable("Registro");
            HasKey(c => c.IdRegistro);
            Property(c=>c.Descricao);
            Property(c => c.DtRegistro);
            Property(c => c.Hora);
            Property(c=>c.Usuario);
        }
    }
}
