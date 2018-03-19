using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Mapping
{
    public class Endereco: EntityTypeConfiguration<Entidades.Endereco>
    {
        public Endereco()
        {
            ToTable("Endereco");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("IdEndereco");
            Property(c => c.Bairro).HasColumnType("varchar").HasMaxLength(50);
            Property(c => c.Complemento).HasColumnType("varchar");
            Property(c => c.DDD).HasColumnType("int");
            Property(c => c.Localidade).HasColumnType("varchar");
            Property(c => c.Telefone.Numero).HasColumnType("int").HasColumnName("Contato");
            Property(c => c.TipoContat).HasColumnType("varchar");
            Property(c => c.Uf).HasColumnType("varchar");

            // 1 para 1
            HasRequired(x => x.Biblioteca)
                               .WithMany()
            .HasForeignKey(x => x.IdBlioteca);

        }
    }
}
