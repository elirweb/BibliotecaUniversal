﻿using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Usuario.Data.Contexto
{
    public class Contexto: DbContext
    {
        public Contexto():base (Biblioteca.Core.Domain.Util.Descriptografar.Descript(ConfigurationManager.ConnectionStrings["Contexto"].ConnectionString.ToString())) // Contexto
        {
            Database.Log = obj => System.Diagnostics.Debug.Write(obj);
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

        }

        public DbSet<Domain.Entidade.Usuario> Usuario { get; set; }
        public DbSet<Domain.Entidade.EnderecoUsuario> EnderecoUsuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removendo a pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            //removendo os cascade
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new Domain.Mapping.Usuario());
            modelBuilder.Entity<Domain.Entidade.Usuario>().Ignore(c => c.ConfirmaSenha);
            modelBuilder.Entity<Domain.Entidade.Usuario>().Ignore(c => c.ValidacaoResultado);

            modelBuilder.Configurations.Add(new Domain.Mapping.Endereco());
            modelBuilder.Entity<Domain.Entidade.EnderecoUsuario>().Ignore(c => c.ValidationResult);
            
        }
    }
}
