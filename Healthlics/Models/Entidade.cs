using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healthlics.Models
{
    public class Entidade
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int IdPaciente { get; set; }
        public int IdCuidador { get; set; }
    }
}