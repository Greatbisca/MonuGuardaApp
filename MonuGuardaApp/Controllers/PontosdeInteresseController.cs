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
    public class PontosdeInteresseController : Controller
    {
        private readonly MonuGuardaAppContext _context;

        public PontosdeInteresseController(MonuGuardaAppContext context)
        {
            _context = context;
        }

        // GET: PontosdeInteresse
        public IActionResult Index(string name = null, int page = 1)
        {
            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItems = _context.PontosdeInteresse.Where(p => name == null || p.Nome.Contains(name)).Count()
            };
            var monuGuardaAppContext = _context.PontosdeInteresse.Include(p => p.Concelho);
            return View(
                new PontosdeInteresseListViewModel
                {
                    PontosdeInteresse = _context.PontosdeInteresse.Where(p => name == null || p.Nome.Contains(name))
                        .OrderBy(p => p.Nome)
                        .Skip((page - 1) * pagination.PageSize)
                        .Take(pagination.PageSize).Include(p => p.Concelho),
                    Pagination = pagination,
                    SearchName = name
                }
            );
        }

        // GET: PontosdeInteresse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontosdeInteresse = await _context.PontosdeInteresse
                .Include(p => p.Concelho)
                .Include(p => p.Freguesia)
                .FirstOrDefaultAsync(m => m.PontosdeInteresseId == id);
            if (pontosdeInteresse == null)
            {
                return NotFound();
            }

            return View(pontosdeInteresse);
        }

        // GET: PontosdeInteresse/Create
        public IActionResult Create()
        {
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "ConcelhoId", "Nome");
            ViewData["FreguesiaId"] = new SelectList(_context.Freguesia, "FreguesiaId", "Nome");
            return View();
        }

        // POST: PontosdeInteresse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PontosdeInteresseId,Nome,FreguesiaId,ConcelhoId,Morada,Coordenadas")] PontosdeInteresse pontosdeInteresse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontosdeInteresse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "ConcelhoId", "Nome", pontosdeInteresse.ConcelhoId);
            ViewData["FreguesiaId"] = new SelectList(_context.Freguesia, "FreguesiaId", "Nome", pontosdeInteresse.FreguesiaId);
            return View(pontosdeInteresse);
        }

        // GET: PontosdeInteresse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontosdeInteresse = await _context.PontosdeInteresse.FindAsync(id);
            if (pontosdeInteresse == null)
            {
                return NotFound();
            }
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "ConcelhoId", "Nome", pontosdeInteresse.ConcelhoId);
            ViewData["FreguesiaId"] = new SelectList(_context.Freguesia, "FreguesiaId", "Nome", pontosdeInteresse.FreguesiaId);
            return View(pontosdeInteresse);
        }

        // POST: PontosdeInteresse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PontosdeInteresseId,Nome,FreguesiaId,ConcelhoId,Morada,Coordenadas")] PontosdeInteresse pontosdeInteresse)
        {
            if (id != pontosdeInteresse.PontosdeInteresseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pontosdeInteresse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontosdeInteresseExists(pontosdeInteresse.PontosdeInteresseId))
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
            ViewData["ConcelhoId"] = new SelectList(_context.Concelho, "ConcelhoId", "Nome", pontosdeInteresse.ConcelhoId);
            ViewData["FreguesiaId"] = new SelectList(_context.Freguesia, "FreguesiaId", "Nome", pontosdeInteresse.FreguesiaId);
            return View(pontosdeInteresse);
        }

        // GET: PontosdeInteresse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pontosdeInteresse = await _context.PontosdeInteresse
                .Include(p => p.Concelho)
                .Include(p => p.Freguesia)
                .FirstOrDefaultAsync(m => m.PontosdeInteresseId == id);
            if (pontosdeInteresse == null)
            {
                return NotFound();
            }

            return View(pontosdeInteresse);
        }

        // POST: PontosdeInteresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pontosdeInteresse = await _context.PontosdeInteresse.FindAsync(id);
            _context.PontosdeInteresse.Remove(pontosdeInteresse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontosdeInteresseExists(int id)
        {
            return _context.PontosdeInteresse.Any(e => e.PontosdeInteresseId == id);
        }
    }
}
