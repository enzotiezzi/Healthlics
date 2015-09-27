namespace Healthlics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PacienteRemedio", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PacienteRemedio", "Nome");
        }
    }
}
