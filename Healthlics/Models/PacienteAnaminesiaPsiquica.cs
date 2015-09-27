using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healthlics.Models
{
    public class PacienteAnaminesiaPsiquica : Entidade
    {
        public int IdAnaminesiaPsiquica { get; set; }
        public AnaminesiaPsiquica AnaminesiaPsiquica { get; set; }
        public string Nome { get; set; }
        public bool Valor { get; set; }
    }
}