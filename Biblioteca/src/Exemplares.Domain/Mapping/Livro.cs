
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Exemplares.Domain.Mapping
{
    public class Livro: EntityTypeConfiguration<Entidade.Livro>
    {
        public Livro()
        {
            ToTable("Livro");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
             .HasColumnName("IdLivro");
            Property(c => c.Codigo);
            Property(c => c.Titulo);
            Property(c => c.DtCadastro);
            Property(c => c.Descricao);
            Property(c => c.HoraCadastro);
            Property(c => c.QtdPagina);
            Property(c => c.Area);
            Property(c => c.Capa);

            HasRequired(x => x.Biblioteca)
                               .WithMany()
            .HasForeignKey(x => x.IdBiblioteca);
        }
    }
}
