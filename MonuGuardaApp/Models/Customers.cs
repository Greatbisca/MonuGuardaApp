using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class Customers
    {
        public int CustomersId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Email { get; set; }
        public int Telemovel { get; set; }


    }
}
