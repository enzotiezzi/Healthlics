using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healthlics.Models
{
    public class Cuidador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public List<Paciente> Pacientes { get; set; }
    }
}