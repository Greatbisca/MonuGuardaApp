﻿using System;
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
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário colocar o local de partida")]
        public string LocaldePartida { get; set; }

        [Required(ErrorMessage = "É necessário colocar o local de chegada")]
        public string LocaldeChegada { get; set; }

        [Required(ErrorMessage = "É necessário colocar a data da visita guiada")]
        public DateTime DatadaVisita { get; set; }

        [Required(ErrorMessage = "É necessário colocar descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "É necessário colocar o número máximo de pessoas")]
        public int NMaxPessoas { get; set; }
        public bool Completo { get; set; }
    }
}
