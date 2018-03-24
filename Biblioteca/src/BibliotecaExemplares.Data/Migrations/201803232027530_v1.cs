namespace BibliotecaExemplares.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LivrosBiblioteca", "BibliotecaRefId", "dbo.Bibliotecas");
            DropForeignKey("dbo.LivrosBiblioteca", "ExemplaresRefId", "dbo.Exemplares");
            DropIndex("dbo.LivrosBiblioteca", new[] { "BibliotecaRefId" });
            DropIndex("dbo.LivrosBiblioteca", new[] { "ExemplaresRefId" });
            CreateTable(
                "dbo.LivroBiblioteca",
                c => new
                    {
                        LivBId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.LivBId);
            
            CreateTable(
                "dbo.Bibliotecaria",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RazaoSocial = c.String(),
                        Cnpj_Numero = c.Int(nullable: false),
                        Usuario = c.String(),
                        Senha_CodigoSenha = c.String(),
                        Email_Endereco = c.String(),
                        Situacao = c.Boolean(nullable: false),
                        Imagem = c.String(),
                        DtCadastro = c.DateTime(nullable: false),
                        DtUltmaAlteracao = c.DateTime(),
                        HoraCadastro = c.Time(nullable: false, precision: 7),
                        HoraVisualizacao = c.Time(precision: 7),
                        LivroBiblioteca_LivBId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LivroBiblioteca", t => t.LivroBiblioteca_LivBId)
                .Index(t => t.LivroBiblioteca_LivBId);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codigo = c.String(),
                        Titulo = c.String(),
                        DtCadastro = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        HoraCadastro = c.Time(nullable: false, precision: 7),
                        QtdPagina = c.Int(nullable: false),
                        Categoria = c.Int(nullable: false),
                        Capa = c.String(),
                        Ativo = c.Boolean(nullable: false),
                        Editora = c.String(),
                        LivroBiblioteca_LivBId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LivroBiblioteca", t => t.LivroBiblioteca_LivBId)
                .Index(t => t.LivroBiblioteca_LivBId);
            
            DropTable("dbo.Bibliotecas");
            DropTable("dbo.Exemplares");
            DropTable("dbo.LivrosBiblioteca");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LivrosBiblioteca",
                c => new
                    {
                        BibliotecaRefId = c.Int(nullable: false),
                        ExemplaresRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BibliotecaRefId, t.ExemplaresRefId });
            
            CreateTable(
                "dbo.Exemplares",
                c => new
                    {
                        LivroId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.LivroId);
            
            CreateTable(
                "dbo.Bibliotecas",
                c => new
                    {
                        BibId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BibId);
            
            DropForeignKey("dbo.Livro", "LivroBiblioteca_LivBId", "dbo.LivroBiblioteca");
            DropForeignKey("dbo.Bibliotecaria", "LivroBiblioteca_LivBId", "dbo.LivroBiblioteca");
            DropIndex("dbo.Livro", new[] { "LivroBiblioteca_LivBId" });
            DropIndex("dbo.Bibliotecaria", new[] { "LivroBiblioteca_LivBId" });
            DropTable("dbo.Livro");
            DropTable("dbo.Bibliotecaria");
            DropTable("dbo.LivroBiblioteca");
            CreateIndex("dbo.LivrosBiblioteca", "ExemplaresRefId");
            CreateIndex("dbo.LivrosBiblioteca", "BibliotecaRefId");
            AddForeignKey("dbo.LivrosBiblioteca", "ExemplaresRefId", "dbo.Exemplares", "LivroId", cascadeDelete: true);
            AddForeignKey("dbo.LivrosBiblioteca", "BibliotecaRefId", "dbo.Bibliotecas", "BibId", cascadeDelete: true);
        }
    }
}
