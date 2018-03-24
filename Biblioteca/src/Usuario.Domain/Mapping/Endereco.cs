using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Domain.Mapping
{
    public class Endereco: EntityTypeConfiguration<Entidade.EnderecoUsuario>
    {
        public Endereco()
        {
            ToTable("EnderecoUsuario");
            HasKey(c=>c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
              .HasColumnName("IdEndereco");
            Property(c => c.Bairro).HasColumnType("varchar").HasMaxLength(50);
            Property(c => c.Localidade).HasColumnType("varchar");
            Property(c => c.Uf).HasColumnType("varchar");

            // 1 para 1
            HasRequired(x => x.Usuario)
                               .WithMany()
            .HasForeignKey(x => x.IdUsuario);

        }
    }
}
