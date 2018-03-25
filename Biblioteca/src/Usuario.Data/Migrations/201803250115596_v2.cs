namespace Usuario.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "Grupo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "Grupo");
        }
    }
}
