using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MonuGuardaApp.Data;
using MonuGuardaApp.Models;

namespace MonuGuardaApp.Controllers
{
    public class ReservaVisitasController : Controller
    {
        private readonly MonuGuardaAppContext _context;

        public ReservaVisitasController(MonuGuardaAppContext context)
        {
            _context = context;
        }

        // GET: ReservaVisitas
        public IActionResult Index(DateTime? dataInicio = null, DateTime? dataFim = null, int page = 1)
        {
            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItems = _context.ReservaVisita.Where(p =>
                    (!dataInicio.HasValue || p.DataReserva >= dataInicio.Value) &&
                    (!dataFim.HasValue || p.DataReserva <= dataFim.Value)
                ).Count()
            };

            return View(
                new ReservaVisitasListViewModel
                {
                    ReservaVisitas = _context.ReservaVisita.Where(p =>
                         (!dataInicio.HasValue || p.DataReserva >= dataInicio.Value) &&
                         (!dataFim.HasValue || p.DataReserva <= dataFim.Value))
                        .OrderBy(p => p.DataReserva)
                        .Skip((page - 1) * pagination.PageSize)
                        .Take(pagination.PageSize),
                    Pagination = pagination,
                    SearchDataInicio = dataInicio,
                    SearchDataFim = dataFim
                }
            );
        }

        // GET: ReservaVisitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaVisita = await _context.ReservaVisita
                .Include(r => r.Turista)
                .Include(r => r.VisitasGuiadas)
                .FirstOrDefaultAsync(m => m.ReservaVisitaId == id);
            if (reservaVisita == null)
            {
                return NotFound();
            }

            return View(reservaVisita);
        }

        // GET: ReservaVisitas/Create
        public IActionResult Create()
        {
            ViewData["TuristaId"] = new SelectList(_context.Set<Turista>(), "TuristaId", "Nome");
            ViewData["VisitasGuiadasId"] = new SelectList(_context.Set<VisitasGuiadas>(), "VisitasGuiadasId", "Nome");
            return View();
        }

        // POST: ReservaVisitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservaVisitaId,TuristaId,VisitasGuiadasId,DataReserva,NPessoas")] ReservaVisita reservaVisita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservaVisita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TuristaId"] = new SelectList(_context.Set<Turista>(), "TuristaId", "Nome", reservaVisita.TuristaId);
            ViewData["VisitasGuiadasId"] = new SelectList(_context.Set<VisitasGuiadas>(), "VisitasGuiadasId", "Nome", reservaVisita.VisitasGuiadasId);
            return View(reservaVisita);
        }

        // GET: ReservaVisitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaVisita = await _context.ReservaVisita.FindAsync(id);
            if (reservaVisita == null)
            {
                return NotFound();
            }
            ViewData["TuristaId"] = new SelectList(_context.Set<Turista>(), "TuristaId", "Nome", reservaVisita.TuristaId);
            ViewData["VisitasGuiadasId"] = new SelectList(_context.Set<VisitasGuiadas>(), "VisitasGuiadasId", "Nome", reservaVisita.VisitasGuiadasId);
            return View(reservaVisita);
        }

        // POST: ReservaVisitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservaVisitaId,TuristaId,VisitasGuiadasId,DataReserva,NPessoas")] ReservaVisita reservaVisita)
        {
            if (id != reservaVisita.ReservaVisitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservaVisita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaVisitaExists(reservaVisita.ReservaVisitaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TuristaId"] = new SelectList(_context.Set<Turista>(), "TuristaId", "Nome", reservaVisita.TuristaId);
            ViewData["VisitasGuiadasId"] = new SelectList(_context.Set<VisitasGuiadas>(), "VisitasGuiadasId", "Nome", reservaVisita.VisitasGuiadasId);
            return View(reservaVisita);
        }

        // GET: ReservaVisitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservaVisita = await _context.ReservaVisita
                .Include(r => r.Turista)
                .Include(r => r.VisitasGuiadas)
                .FirstOrDefaultAsync(m => m.ReservaVisitaId == id);
            if (reservaVisita == null)
            {
                return NotFound();
            }

            return View(reservaVisita);
        }

        // POST: ReservaVisitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservaVisita = await _context.ReservaVisita.FindAsync(id);
            _context.ReservaVisita.Remove(reservaVisita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaVisitaExists(int id)
        {
            return _context.ReservaVisita.Any(e => e.ReservaVisitaId == id);
        }
    }
}
