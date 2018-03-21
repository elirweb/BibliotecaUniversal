
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Log.Data.Contexto
{
    public class Contexto: DbContext
    {
        public Contexto() : base("Contexto")
        {
            Database.Log = obj => System.Diagnostics.Debug.Write(obj);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Domain.Entidade.Registro> Registro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removendo a pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //removendo os cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new Domain.Mapping.Registro());


        }
    }
}
