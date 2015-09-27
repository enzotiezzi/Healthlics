namespace Healthlics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agenda", "Data", c => c.String());
            AlterColumn("dbo.AnaminesiaFisica", "Data", c => c.String());
            AlterColumn("dbo.AnaminesiaPsiquica", "Data", c => c.String());
            AlterColumn("dbo.Paciente", "Nascimento", c => c.String());
            AlterColumn("dbo.Paciente", "Data", c => c.String());
            AlterColumn("dbo.Observacao", "Data", c => c.String());
            AlterColumn("dbo.PacienteAnaminesiaFisica", "Data", c => c.String());
            AlterColumn("dbo.PacienteAnaminesiaPsiquica", "Data", c => c.String());
            AlterColumn("dbo.PacienteRemedio", "Data", c => c.String());
            AlterColumn("dbo.Pressao", "Data", c => c.String());
            AlterColumn("dbo.Temperatura", "Data", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Temperatura", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pressao", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PacienteRemedio", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PacienteAnaminesiaPsiquica", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PacienteAnaminesiaFisica", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Observacao", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Paciente", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Paciente", "Nascimento", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AnaminesiaPsiquica", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AnaminesiaFisica", "Data", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Agenda", "Data", c => c.DateTime(nullable: false));
        }
    }
}
