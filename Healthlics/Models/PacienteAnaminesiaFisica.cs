using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healthlics.Models
{
    public class PacienteAnaminesiaFisica : Entidade
    {
        public int IdAnaminesiaFisica { get; set; }
        public AnaminesiaFisica AnaminesiaFisica { get; set; }
        public string Nome { get; set; }
        public bool Valor { get; set; }
    }
}