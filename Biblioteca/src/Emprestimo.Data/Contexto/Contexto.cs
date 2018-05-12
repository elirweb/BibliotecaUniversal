
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Emprestimo.Data.Contexto
{
    public class Contexto: DbContext
    {
        public Contexto() : base(Biblioteca.Core.Domain.Util.Descriptografar.Descript(ConfigurationManager.ConnectionStrings["Contexto"].ConnectionString.ToString())) // Contexto
        {
            Database.Log = obj => System.Diagnostics.Debug.Write(obj);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Domain.Entidade.Pedido> Pedido { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removendo a pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //removendo os cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new Domain.Mapping.Pedido());

        }
    }


}

