
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UsuarioBiblioteca.Data.Contexto
{
    public class Contexto: DbContext
    {
        public Contexto() : base(Biblioteca.Core.Domain.Util.Descriptografar.Descript(ConfigurationManager.ConnectionStrings["Contexto"].ConnectionString.ToString())) // Contexto
        {
            Database.Log = obj => System.Diagnostics.Debug.Write(obj);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Domain.Entidades.Bibliotecaria> Bibliotecaria { get; set; }
        public DbSet<Domain.Entidades.Endereco> Endereco { get; set; }
        public DbSet<Domain.Entidades.Administradores> Administradores { get; set; }
        public DbSet<Domain.Entidades.Grupos> Grupos { get; set; }
        public DbSet<Domain.Entidades.Livro> Livro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removendo a pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //removendo os cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Ignorando o confirma senha para não ser gerado no banco de dados 

            modelBuilder.Configurations.Add(new Domain.Mapping.Bibliotecaria());
            modelBuilder.Entity<Domain.Entidades.Bibliotecaria>().Ignore(c => c.ConfirmaSenha);
            modelBuilder.Entity<Domain.Entidades.Bibliotecaria>().Ignore(c=>c.ValidacaoResultado);
            modelBuilder.Configurations.Add(new Domain.Mapping.Endereco());
            modelBuilder.Entity<Domain.Entidades.Endereco>().Ignore(c => c.ValidationResult);
            modelBuilder.Entity<Domain.Entidades.Endereco>().Ignore(c => c.tipo);

            modelBuilder.Configurations.Add(new Domain.Mapping.Administrador());
            modelBuilder.Entity<Domain.Entidades.Administradores>().Ignore(c => c.ValidacaoResultado);
            modelBuilder.Entity<Domain.Entidades.Administradores>().Ignore(c => c.ConfirmaSenha);

            modelBuilder.Configurations.Add(new Domain.Mapping.Grupos());
            modelBuilder.Configurations.Add(new Domain.Mapping.Livro());
            modelBuilder.Entity<Domain.Entidades.Livro>().Ignore(c => c.ValidacaoResultado);



        }

    }
}
