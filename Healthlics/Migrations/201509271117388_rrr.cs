namespace Healthlics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rrr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PacienteAnaminesiaFisica", "AnaminesiaFisica_Id", c => c.Int());
            AddColumn("dbo.PacienteAnaminesiaPsiquica", "AnaminesiaPsiquica_Id", c => c.Int());
            CreateIndex("dbo.PacienteAnaminesiaFisica", "AnaminesiaFisica_Id");
            CreateIndex("dbo.PacienteAnaminesiaPsiquica", "AnaminesiaPsiquica_Id");
            AddForeignKey("dbo.PacienteAnaminesiaFisica", "AnaminesiaFisica_Id", "dbo.AnaminesiaFisica", "Id");
            AddForeignKey("dbo.PacienteAnaminesiaPsiquica", "AnaminesiaPsiquica_Id", "dbo.AnaminesiaPsiquica", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PacienteAnaminesiaPsiquica", "AnaminesiaPsiquica_Id", "dbo.AnaminesiaPsiquica");
            DropForeignKey("dbo.PacienteAnaminesiaFisica", "AnaminesiaFisica_Id", "dbo.AnaminesiaFisica");
            DropIndex("dbo.PacienteAnaminesiaPsiquica", new[] { "AnaminesiaPsiquica_Id" });
            DropIndex("dbo.PacienteAnaminesiaFisica", new[] { "AnaminesiaFisica_Id" });
            DropColumn("dbo.PacienteAnaminesiaPsiquica", "AnaminesiaPsiquica_Id");
            DropColumn("dbo.PacienteAnaminesiaFisica", "AnaminesiaFisica_Id");
        }
    }
}
