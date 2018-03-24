
using System.Data.Entity.ModelConfiguration;

namespace UsuarioBiblioteca.Mapping
{
    public class Grupos: EntityTypeConfiguration<Entidades.Grupos>
    {
        public Grupos()
        {
            ToTable("Grupo");
            HasKey(c => c.Id);
            Property(c => c.Grupo).HasColumnType("varchar");
        }
    }
}
