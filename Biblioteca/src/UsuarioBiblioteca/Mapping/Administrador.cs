using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioBiblioteca.Mapping
{
    public class Administrador: EntityTypeConfiguration<Entidades.Administradores>
    {
        public Administrador()
        {
            ToTable("Administrador");
            HasKey(c => c.Id);
            Property(c=>c.Login).HasColumnType("varchar");
            Property(c => c.Nome).HasColumnType("varchar");
            Property(c => c.Senha.CodigoSenha).HasColumnType("varchar");
            Property(c => c.Grupo).HasColumnType("varchar");
            Property(c => c.Email.Endereco).HasColumnType("varchar").HasColumnName("Email");

        }
    }
}
