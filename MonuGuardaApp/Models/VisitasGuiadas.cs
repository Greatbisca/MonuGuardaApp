using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class VisitasGuiadas
    {
        public int VisitasGuiadasId { get; set; }
        public int GuiaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public string LocalPartida { get; set; }
        public string LocalChegada { get; set; }
        public DateTimeOffset DataVisita { get; set; }
        public string Morada { get; set; }
        public int Telemovel { get; set; }
        public int NMaxPessoas { get; set; }
        public bool Completo { get; set; }
    }
}
