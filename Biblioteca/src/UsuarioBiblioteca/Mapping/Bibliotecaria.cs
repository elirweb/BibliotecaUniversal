﻿using System.Data.Entity.ModelConfiguration;

namespace UsuarioBiblioteca.Domain.Mapping
{
    public class Bibliotecaria: EntityTypeConfiguration<Domain.Entidades.Bibliotecaria>
    {
        public Bibliotecaria()
        {
            ToTable("Bibliotecaria");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("IdBiblioteca");
            Property(c => c.RazaoSocial).HasColumnType("varchar").HasMaxLength(50);
            Property(c => c.Cnpj._cnpj).HasColumnName("Cnpj");
            Property(c => c.Usuario).HasColumnType("varchar");
            Property(c => c.Senha.CodigoSenha).HasColumnType("varchar").HasColumnName("Senha");
            Property(c => c.Email.Endereco).HasColumnType("varchar").HasColumnName("Email");
            Property(c => c.Situacao).HasColumnType("bit");
            Property(c => c.Imagem).HasColumnType("varchar");
            Property(c => c.DtCadastro).HasColumnType("Datetime");
            Property(c => c.HoraCadastro).HasColumnType("time");
            Property(c => c.HoraVisualizacao).HasColumnType("time");

            
        }
    }
}
