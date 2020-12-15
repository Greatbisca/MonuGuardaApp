using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class PontosdeInteresse
    {
        public int PontosdeInteresseId { get; set; }

        public string Nome { get; set; }

        public string Tipo { get; set; }

        public string Freguesia { get; set; }

        public string Concelho { get; set; }

        public string EstatutoPatrimonial { get; set; }

    }
}
