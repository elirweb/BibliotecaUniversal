
using System.Data.Entity.ModelConfiguration;

namespace Usuario.Domain.Mapping
{
    public class Usuario: EntityTypeConfiguration<Entidades.Usuario>
    {
        public Usuario()
        {
            ToTable("Usuario");
            HasKey(c=>c.Id);
            Property(c => c.Id).HasColumnName("IdUsuario");
            Property(c => c.Nome);
            Property(c => c.Login);
            Property(c => c.Senha.CodigoSenha).HasColumnName("Senha");
            Property(c => c.Email.Endereco).HasColumnName("Email");
            Property(c => c.Cpf.Codigo).HasColumnName("Cpf");


        }
    }
}
