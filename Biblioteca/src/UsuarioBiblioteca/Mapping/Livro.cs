using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Domain.Mapping
{
    public class Livro: EntityTypeConfiguration<Domain.Entidades.Livro>
    {
        public Livro()
        {
            ToTable("Livro");
            HasKey(c => c.Id);
            Property(c => c.Editora).HasColumnType("varchar");
            Property(c => c.Descricao).HasColumnType("varchar");
            Property(c => c.Ativo).HasColumnType("bit");
            Property(c => c.Titulo).HasColumnType("varchar");
            Property(c => c.QtdPg).HasColumnType("int");

            // configures one-to-many relationship
            HasRequired<Entidades.Bibliotecaria>(s => s.Biblioteca)
            .WithMany(g => g.Livro)
            .HasForeignKey<Guid>(s => s.IdBiblioteca);


        }
    }
}
