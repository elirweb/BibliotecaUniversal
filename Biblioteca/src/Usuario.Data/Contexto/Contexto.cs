using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuario.Data.Contexto
{
    public class Contexto: DbContext
    {
        public Contexto():base ("Contexto")
        {
            Database.Log = obj => System.Diagnostics.Debug.Write(obj);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Domain.Entidades.Usuario> Usuario { get; set; }
        public DbSet<Domain.Entidades.Endereco> Endereco { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removendo a pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //removendo os cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new Domain.Mapping.Usuario());
            modelBuilder.Entity<Domain.Entidades.Usuario>().Ignore(c => c.ConfirmaSenha);
            modelBuilder.Entity<Domain.Entidades.Usuario>().Ignore(c => c.ValidationResult);

            modelBuilder.Configurations.Add(new Domain.Mapping.Endereco());
            modelBuilder.Entity<Domain.Entidades.Endereco>().Ignore(c => c.ValidationResult);
            
        }
    }
}
