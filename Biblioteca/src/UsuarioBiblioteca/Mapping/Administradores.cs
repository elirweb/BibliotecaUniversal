using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Domain.Mapping
{
    public class Administradores: EntityTypeConfiguration<Domain.Entidades.Administradores>
    {
        public Administradores()
        {
            ToTable("Administradores");
            HasKey(c => c.Id);
            Property(c=>c.Login).HasColumnType("varchar");
            Property(c => c.Nome).HasColumnType("varchar");
            Property(c => c.Senha.CodigoSenha).HasColumnType("varchar").HasColumnName("Senha");
            Property(c => c.Grupo).HasColumnType("varchar");
            Property(c => c.Email.Endereco).HasColumnType("varchar").HasColumnName("Email");

        }
    }
}
