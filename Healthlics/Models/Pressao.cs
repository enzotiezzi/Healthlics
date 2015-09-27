using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healthlics.Models
{
    public class Pressao : Entidade
    {
        public int Sistolica { get; set; }
        public int Diastólica { get; set; }
    }
}