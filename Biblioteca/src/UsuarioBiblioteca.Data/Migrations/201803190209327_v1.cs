namespace UsuarioBiblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bibliotecaria",
                c => new
                    {
                        IdBiblioteca = c.Guid(nullable: false, identity: true),
                        RazaoSocial = c.String(maxLength: 50, unicode: false),
                        Cnpj = c.Int(nullable: false),
                        Usuario = c.String(maxLength: 8000, unicode: false),
                        Senha = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        Situacao = c.Boolean(nullable: false),
                        Imagem = c.String(maxLength: 8000, unicode: false),
                        DtCadastro = c.DateTime(nullable: false),
                        DtUltmaAlteracao = c.DateTime(),
                        HoraCadastro = c.Time(nullable: false, precision: 7),
                        HoraVisualizacao = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.IdBiblioteca);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        IdEndereco = c.Guid(nullable: false, identity: true),
                        Bairro = c.String(maxLength: 50, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 8000, unicode: false),
                        Localidade = c.String(maxLength: 8000, unicode: false),
                        Uf = c.String(maxLength: 8000, unicode: false),
                        DDD = c.Int(nullable: false),
                        Contato = c.Int(nullable: false),
                        IdBlioteca = c.Guid(nullable: false),
                        TipoContat = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.IdEndereco)
                .ForeignKey("dbo.Bibliotecaria", t => t.IdBlioteca)
                .Index(t => t.IdBlioteca);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "IdBlioteca", "dbo.Bibliotecaria");
            DropIndex("dbo.Endereco", new[] { "IdBlioteca" });
            DropTable("dbo.Endereco");
            DropTable("dbo.Bibliotecaria");
        }
    }
}
