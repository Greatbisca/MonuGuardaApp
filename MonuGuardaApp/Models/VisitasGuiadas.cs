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

        public Guia Guia { get; set; }

        [Required(ErrorMessage = "É necessário colocar nome")]
        [StringLength(20)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário colocar a data da visita guiada")]
        public DateTime DatadaVisita { get; set; }

        [Required(ErrorMessage = "É necessário colocar descrição")]
        [StringLength(200)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "É necessário colocar o número máximo de pessoas")]
        public int NMaxPessoas { get; set; }
        public bool Completo { get; set; }

        public ICollection<ReservaVisita> ReservasVisita { get; set; }
    }
}
