using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class FakeRepository : MonuGuardaRepositorio
    {
        public IEnumerable<VisitasGuiadas> VisitasGuiadas =>
            new List<VisitasGuiadas>
            {
                new VisitasGuiadas
                {
                    VisitasGuiadasId = 1,
                    GuiaId = 1,
                    Nome = "A - B",
                    LocalPartida = "A",
                    LocalChegada = "B",
                    Morada = "Guarda",
                    Telemovel = 967246584,
                    NMaxPessoas = 5,
                }
            };
    }
}
