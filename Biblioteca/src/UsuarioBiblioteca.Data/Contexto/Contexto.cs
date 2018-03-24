
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace UsuarioBiblioteca.Data.Contexto
{
    public class Contexto: DbContext
    {
        public Contexto():base("Contexto")
        {
            Database.Log = obj => System.Diagnostics.Debug.Write(obj);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Entidades.Bibliotecaria> Biblioteca { get; set; }
        public DbSet<Entidades.Endereco> Endereco { get; set; }
        public DbSet<Entidades.Administradores> Administradores { get; set; }
        public DbSet<Entidades.Grupos> Grupos { get; set; }
        public DbSet<Entidades.Livro> Livro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removendo a pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //removendo os cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Ignorando o confirma senha para não ser gerado no banco de dados 

            modelBuilder.Configurations.Add(new Mapping.Bibliotecaria());
            modelBuilder.Entity<Entidades.Bibliotecaria>().Ignore(c => c.ConfirmaSenha);
            modelBuilder.Entity<Entidades.Bibliotecaria>().Ignore(c=>c.ValidationResult);
            modelBuilder.Configurations.Add(new Mapping.Endereco());
            modelBuilder.Entity<Entidades.Endereco>().Ignore(c => c.ValidationResult);
            modelBuilder.Entity<Entidades.Endereco>().Ignore(c => c.tipo);

            modelBuilder.Configurations.Add(new Mapping.Administrador());
            modelBuilder.Entity<Entidades.Administradores>().Ignore(c => c.ValidationResult);
            modelBuilder.Entity<Entidades.Administradores>().Ignore(c => c.ConfirmaSenha);

            modelBuilder.Configurations.Add(new Mapping.Grupos());
            modelBuilder.Configurations.Add(new Mapping.Livro());
            modelBuilder.Entity<Entidades.Livro>().Ignore(c => c.ValidationResult);



        }

    }
}
