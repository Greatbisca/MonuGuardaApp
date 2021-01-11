using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class Guia
    {
        public int GuiaId { get; set; }
        public string Nome { get; set; }
        public int Telemovel { get; set; }

        public string Email{ get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Morada { get; set; }
    }
}
