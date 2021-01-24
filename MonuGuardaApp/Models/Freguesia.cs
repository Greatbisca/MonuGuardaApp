using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class Freguesia
    {
        public int FreguesiaId { get; set; }

        [Required(ErrorMessage = "É necessário colocar nome")]
        [StringLength(40)]
        public string Nome { get; set; }
    }
}
