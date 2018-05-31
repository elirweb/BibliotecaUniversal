
using System.Data.Entity.ModelConfiguration;

namespace UsuarioBiblioteca.Domain.Mapping
{
    public class Grupos: EntityTypeConfiguration<Domain.Entidades.Grupos>
    {
        public Grupos()
        {
            ToTable("Grupo");
            HasKey(c => c.Id);
            Property(c => c.Grupo).HasColumnType("varchar");
        }
    }
}
