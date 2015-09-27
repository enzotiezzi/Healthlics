using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Healthlics.Models
{
    public class Paciente : Entidade
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Nascimento { get; set; }
        public string NomeResponsavel { get; set; }
        public string TelefoneResponsavel { get; set; }
        public string Diagnostico { get; set; }
    }
}