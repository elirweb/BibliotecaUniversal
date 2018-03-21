namespace UsuarioBiblioteca.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Endereco", "IdBlioteca", "dbo.Bibliotecaria");
            DropPrimaryKey("dbo.Bibliotecaria");
            AlterColumn("dbo.Bibliotecaria", "IdBiblioteca", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Bibliotecaria", "IdBiblioteca");
            AddForeignKey("dbo.Endereco", "IdBlioteca", "dbo.Bibliotecaria", "IdBiblioteca");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Endereco", "IdBlioteca", "dbo.Bibliotecaria");
            DropPrimaryKey("dbo.Bibliotecaria");
            AlterColumn("dbo.Bibliotecaria", "IdBiblioteca", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Bibliotecaria", "IdBiblioteca");
            AddForeignKey("dbo.Endereco", "IdBlioteca", "dbo.Bibliotecaria", "IdBiblioteca");
        }
    }
}
