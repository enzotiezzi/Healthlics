namespace Healthlics.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Healthlics.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Healthlics.Context";
        }

        protected override void Seed(Healthlics.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Remedios.AddOrUpdate(x => x.Nome, new Models.Remedio { Nome = "Diazepam" });
            context.Remedios.AddOrUpdate(x => x.Nome, new Models.Remedio { Nome = "Dipirona" });
            context.Remedios.AddOrUpdate(x => x.Nome, new Models.Remedio { Nome = "AAS" });
            context.Remedios.AddOrUpdate(x => x.Nome, new Models.Remedio { Nome = "Bi-Profenid" });
            context.Remedios.AddOrUpdate(x => x.Nome, new Models.Remedio { Nome = "Bentazepam" });
            context.Remedios.AddOrUpdate(x => x.Nome, new Models.Remedio { Nome = "Cefalosporina" });

            context.Pacientes.AddOrUpdate(new Models.Paciente { Nome = "Enzo Tiezzi", Cpf = "444.333.222.33", Nascimento = DateTime.Now.ToString() , Data = DateTime.Now.Date.ToString() });
            context.Pacientes.AddOrUpdate(new Models.Paciente { Nome = "Igor Moreira", Cpf = "444.555.122.33", Nascimento = DateTime.Now.ToString(), Data = DateTime.Now.Date.ToString() });
            context.Pacientes.AddOrUpdate(new Models.Paciente { Nome = "Guilherme Bustamante", Cpf = "555.333.233.33", Nascimento = DateTime.Now.ToString(), Data = DateTime.Now.Date.ToString() });


        }
    }
}
