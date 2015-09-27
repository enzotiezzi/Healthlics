using Healthlics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Healthlics.Controllers
{
    public class DiarioBordoController : ApiController

    {
        public List<DiarioBordo> Get()
        {

            Context ctx = new Context();
            //ctx.Pressaos.RemoveRange(ctx.Pressaos.ToList());
            //ctx.Temperaturas.RemoveRange(ctx.Temperaturas.ToList());
            //ctx.PacienteAnaminesiaFisicas.RemoveRange(ctx.PacienteAnaminesiaFisicas.ToList());
            //ctx.PacienteAnaminesiaPsiquicas.RemoveRange(ctx.PacienteAnaminesiaPsiquicas.ToList());
            //ctx.Observacaos.RemoveRange(ctx.Observacaos.ToList());
            //ctx.PacienteRemedios.RemoveRange(ctx.PacienteRemedios.ToList());


            List<Pressao> pressoes = ctx.Pressaos.ToList();
            List<Temperatura> temperaturas = ctx.Temperaturas.ToList();
            List<PacienteAnaminesiaFisica> fisicas = ctx.PacienteAnaminesiaFisicas.ToList();
            List<PacienteAnaminesiaPsiquica> psiquicas = ctx.PacienteAnaminesiaPsiquicas.ToList();
            List<Observacao> observacoes = ctx.Observacaos.ToList();
            List<PacienteRemedio> remedios = ctx.PacienteRemedios.ToList();

            List<DiarioBordo> list = new List<DiarioBordo>();

            foreach (var item in pressoes)
            {
                list.Add(new DiarioBordo { Tipo = "Pressão", Data = item.Data, Valor = item.Sistolica + " : " + item.Diastólica });
            }

            foreach (var item in temperaturas)
            {
                list.Add(new DiarioBordo { Tipo = "Temperatura", Data = item.Data, Valor = item.Grau.ToString() });
            }

            foreach (var item in observacoes)
            {
                list.Add(new DiarioBordo { Tipo = "Observação", Data = item.Data, Valor = item.Texto });
            }

            foreach (var item in fisicas)
            {
                list.Add(new DiarioBordo { Tipo = "Anaminesia Física", Data = item.Data, Valor = item.Nome });
            }

            foreach (var item in psiquicas)
            {
                list.Add(new DiarioBordo { Tipo = "Anaminesia Psiquica", Data = item.Data, Valor = item.Nome });
            }

            return list;
        }

    }
}
