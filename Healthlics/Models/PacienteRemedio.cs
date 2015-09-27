using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healthlics.Models
{
    public class PacienteRemedio : Entidade
    {
        public int IdRemedio { get; set; }
        public string Nome { get; set; }
    }
}