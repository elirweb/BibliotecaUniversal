
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
            modelBuilder.Entity<Entidades.Bibliotecaria>().Ignore(c => c.Endereco);
            modelBuilder.Entity<Entidades.Bibliotecaria>().Ignore(c=>c.ValidationResult);

            modelBuilder.Configurations.Add(new Mapping.Endereco());
            modelBuilder.Entity<Entidades.Endereco>().Ignore(c => c.ValidationResult);
            modelBuilder.Entity<Entidades.Endereco>().Ignore(c => c.tipo);

        }

    }
}
