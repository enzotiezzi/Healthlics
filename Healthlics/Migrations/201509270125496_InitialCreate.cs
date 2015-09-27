namespace Healthlics.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDoRemedio = c.String(),
                        Periocidade = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdCuidador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnaminesiaFisica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Data = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdCuidador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnaminesiaPsiquica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Data = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdCuidador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cuidador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cpf = c.String(),
                        Sexo = c.String(),
                        Nascimento = c.DateTime(nullable: false),
                        NomeResponsavel = c.String(),
                        TelefoneResponsavel = c.String(),
                        Diagnostico = c.String(),
                        Data = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdCuidador = c.Int(nullable: false),
                        Cuidador_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cuidador", t => t.Cuidador_Id)
                .Index(t => t.Cuidador_Id);
            
            CreateTable(
                "dbo.Observacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        Data = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdCuidador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PacienteAnaminesiaFisica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdAnaminesiaFisica = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdCuidador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PacienteAnaminesiaPsiquica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdAnaminesiaPsiquica = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdCuidador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PacienteRemedio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdRemedio = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdCuidador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pressao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sistolica = c.Int(nullable: false),
                        Diastólica = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdCuidador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Remedio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Temperatura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grau = c.Single(nullable: false),
                        Data = c.DateTime(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        IdCuidador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paciente", "Cuidador_Id", "dbo.Cuidador");
            DropIndex("dbo.Paciente", new[] { "Cuidador_Id" });
            DropTable("dbo.Temperatura");
            DropTable("dbo.Remedio");
            DropTable("dbo.Pressao");
            DropTable("dbo.PacienteRemedio");
            DropTable("dbo.PacienteAnaminesiaPsiquica");
            DropTable("dbo.PacienteAnaminesiaFisica");
            DropTable("dbo.Observacao");
            DropTable("dbo.Paciente");
            DropTable("dbo.Cuidador");
            DropTable("dbo.AnaminesiaPsiquica");
            DropTable("dbo.AnaminesiaFisica");
            DropTable("dbo.Agenda");
        }
    }
}
