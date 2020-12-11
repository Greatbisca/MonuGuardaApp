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

        [Required(ErrorMessage = "É necessário colocar o seu Id")]
        public int GuiaId { get; set; }

        [Required(ErrorMessage = "É necessário colocar nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário colocar o local de partida")]
        public string LocalPartida { get; set; }

        [Required(ErrorMessage = "É necessário colocar o local de chegada")]
        public string LocalChegada { get; set; }

        [Required(ErrorMessage = "É necessário colocar a data da visita guiada")]
        public DateTimeOffset DataVisita { get; set; }
        public string Morada { get; set; }

        [Required(ErrorMessage = "É necessário colocar número de telemóvel")]
        public int Telemovel { get; set; }

        [Required(ErrorMessage = "É necessário colocar o número maxímo de pessoas")]
        public int NMaxPessoas { get; set; }
        public bool Completo { get; set; }
    }
}
