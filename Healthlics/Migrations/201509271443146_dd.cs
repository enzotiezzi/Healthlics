namespace Healthlics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PacienteAnaminesiaFisica", "Nome", c => c.String());
            AddColumn("dbo.PacienteAnaminesiaFisica", "Valor", c => c.Boolean(nullable: false));
            AddColumn("dbo.PacienteAnaminesiaPsiquica", "Nome", c => c.String());
            AddColumn("dbo.PacienteAnaminesiaPsiquica", "Valor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PacienteAnaminesiaPsiquica", "Valor");
            DropColumn("dbo.PacienteAnaminesiaPsiquica", "Nome");
            DropColumn("dbo.PacienteAnaminesiaFisica", "Valor");
            DropColumn("dbo.PacienteAnaminesiaFisica", "Nome");
        }
    }
}
