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
    public class PontosVisitaController : Controller
    {
        private readonly MonuGuardaAppContext _context;

        public PontosVisitaController(MonuGuardaAppContext context)
        {
            _context = context;
        }

        // GET: PontosVisita
        public async Task<IActionResult> Index()
        {
            var monuGuardaAppContext = _context.PontosVisita.Include(p => p.PontosdeInteresse).Include(p => p.VisitasGuiadas);
            return View(await monuGuardaAppContext.ToListAsync());
        }

        // GET: PontosVisita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontosVisita = await _context.PontosVisita
                .Include(p => p.PontosdeInteresse)
                .Include(p => p.VisitasGuiadas)
                .FirstOrDefaultAsync(m => m.PontosVisitaId == id);
            if (pontosVisita == null)
            {
                return NotFound();
            }

            return View(pontosVisita);
        }

        // GET: PontosVisita/Create
        public IActionResult Create()
        {
            ViewData["PontosdeInteresseId"] = new SelectList(_context.PontosdeInteresse, "PontosdeInteresseId", "PontosdeInteresseId");
            ViewData["VisitasGuiadasId"] = new SelectList(_context.VisitasGuiadas, "VisitasGuiadasId", "Descricao");
            return View();
        }

        // POST: PontosVisita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PontosVisitaId,PontosdeInteresseId,VisitasGuiadasId,Ordem")] PontosVisita pontosVisita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontosVisita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PontosdeInteresseId"] = new SelectList(_context.PontosdeInteresse, "PontosdeInteresseId", "PontosdeInteresseId", pontosVisita.PontosdeInteresseId);
            ViewData["VisitasGuiadasId"] = new SelectList(_context.VisitasGuiadas, "VisitasGuiadasId", "Descricao", pontosVisita.VisitasGuiadasId);
            return View(pontosVisita);
        }

        // GET: PontosVisita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontosVisita = await _context.PontosVisita.FindAsync(id);
            if (pontosVisita == null)
            {
                return NotFound();
            }
            ViewData["PontosdeInteresseId"] = new SelectList(_context.PontosdeInteresse, "PontosdeInteresseId", "PontosdeInteresseId", pontosVisita.PontosdeInteresseId);
            ViewData["VisitasGuiadasId"] = new SelectList(_context.VisitasGuiadas, "VisitasGuiadasId", "Descricao", pontosVisita.VisitasGuiadasId);
            return View(pontosVisita);
        }

        // POST: PontosVisita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PontosVisitaId,PontosdeInteresseId,VisitasGuiadasId,Ordem")] PontosVisita pontosVisita)
        {
            if (id != pontosVisita.PontosVisitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontosVisita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontosVisitaExists(pontosVisita.PontosVisitaId))
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
            ViewData["PontosdeInteresseId"] = new SelectList(_context.PontosdeInteresse, "PontosdeInteresseId", "PontosdeInteresseId", pontosVisita.PontosdeInteresseId);
            ViewData["VisitasGuiadasId"] = new SelectList(_context.VisitasGuiadas, "VisitasGuiadasId", "Descricao", pontosVisita.VisitasGuiadasId);
            return View(pontosVisita);
        }

        // GET: PontosVisita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontosVisita = await _context.PontosVisita
                .Include(p => p.PontosdeInteresse)
                .Include(p => p.VisitasGuiadas)
                .FirstOrDefaultAsync(m => m.PontosVisitaId == id);
            if (pontosVisita == null)
            {
                return NotFound();
            }

            return View(pontosVisita);
        }

        // POST: PontosVisita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontosVisita = await _context.PontosVisita.FindAsync(id);
            _context.PontosVisita.Remove(pontosVisita);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontosVisitaExists(int id)
        {
            return _context.PontosVisita.Any(e => e.PontosVisitaId == id);
        }
    }
}
