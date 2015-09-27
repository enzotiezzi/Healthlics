using Healthlics.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Healthlics
{
    public class Context : DbContext
    {
        public Context()
            : base(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
        {
            Ini();
        }

        internal Context(string connString)
            : base(connString)
        {
            Ini();
        }

        private void Ini()
        {
       Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Healthlics.Migrations.Configuration>());
        }

        public DbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Pressao>().HasKey(x => x.Id);
            modelBuilder.Entity<Temperatura>().HasKey(x => x.Id);
            modelBuilder.Entity<Cuidador>().HasKey(x => x.Id).HasMany<Paciente>(x => x.Pacientes);
            modelBuilder.Entity<AnaminesiaFisica>().HasKey(x => x.Id);
            modelBuilder.Entity<AnaminesiaPsiquica>().HasKey(x => x.Id);
            modelBuilder.Entity<Observacao>().HasKey(x => x.Id);
            modelBuilder.Entity<Paciente>().HasKey(x => x.Id);
            modelBuilder.Entity<Agenda>().HasKey(x => x.Id);
            modelBuilder.Entity<PacienteAnaminesiaFisica>().HasKey(x => x.Id).HasOptional(x => x.AnaminesiaFisica);
            modelBuilder.Entity<PacienteAnaminesiaPsiquica>().HasKey(x => x.Id).HasOptional(x => x.AnaminesiaPsiquica);
            modelBuilder.Entity<Remedio>().HasKey(x => x.Id);
            modelBuilder.Entity<PacienteRemedio>().HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Healthlics.Models.Agenda> Agenda { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.AnaminesiaFisica> AnaminesiaFisicas { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.AnaminesiaPsiquica> AnaminesiaPsiquicas { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.Cuidador> Cuidadors { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.Observacao> Observacaos { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.Paciente> Pacientes { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.PacienteAnaminesiaFisica> PacienteAnaminesiaFisicas { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.PacienteAnaminesiaPsiquica> PacienteAnaminesiaPsiquicas { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.Pressao> Pressaos { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.Temperatura> Temperaturas { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.Remedio> Remedios { get; set; }

        public System.Data.Entity.DbSet<Healthlics.Models.PacienteRemedio> PacienteRemedios { get; set; }
    }
}