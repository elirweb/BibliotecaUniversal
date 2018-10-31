namespace Usuario.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnderecoUsuario",
                c => new
                    {
                        IdEndereco = c.Guid(nullable: false, identity: true),
                        Localidade = c.String(maxLength: 8000, unicode: false),
                        Bairro = c.String(maxLength: 50, unicode: false),
                        Numero = c.Int(nullable: false),
                        Cidade = c.String(),
                        Uf = c.String(maxLength: 8000, unicode: false),
                        IdUsuario = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdEndereco)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        IdUsuario = c.Guid(nullable: false),
                        Nome = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                        Email = c.String(),
                        Cpf = c.String(),
                        Grupo = c.String(),
                    })
                .PrimaryKey(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnderecoUsuario", "IdUsuario", "dbo.Usuario");
            DropIndex("dbo.EnderecoUsuario", new[] { "IdUsuario" });
            DropTable("dbo.Usuario");
            DropTable("dbo.EnderecoUsuario");
        }
    }
}
