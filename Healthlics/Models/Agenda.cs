using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healthlics.Models
{
    public class Agenda : Entidade
    {
        public string NomeDoRemedio { get; set; }
        public int Periocidade { get; set; }
    }
}