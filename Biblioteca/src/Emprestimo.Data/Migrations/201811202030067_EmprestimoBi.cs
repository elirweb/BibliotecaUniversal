namespace Emprestimo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmprestimoBi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UsuarioId = c.Guid(nullable: false),
                        BibliotecaId = c.Guid(nullable: false),
                        LivroId = c.Guid(nullable: false),
                        DtPedido = c.DateTime(nullable: false),
                        HoraPedido = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pedido");
        }
    }
}
