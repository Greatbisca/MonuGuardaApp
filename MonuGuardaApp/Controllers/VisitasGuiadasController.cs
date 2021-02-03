using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MonuGuardaApp.Data;
using MonuGuardaApp.Models;

namespace MonuGuardaApp.Controllers
{
    public class VisitasGuiadasController : Controller
    {
        private readonly MonuGuardaAppContext _context;

        public VisitasGuiadasController(MonuGuardaAppContext context)
        {
            _context = context;
        }
        
        // GET: VisitasGuiadas
        public IActionResult Index(string name = null, int page = 1)
        {
            var pagination = new PagingInfo
            {
                CurrentPage = page,
                PageSize = PagingInfo.DEFAULT_PAGE_SIZE,
                TotalItems = _context.VisitasGuiadas.Where(p => name == null || p.Guia.Nome.Contains(name) || p.Nome.Contains(name)).Count()
            };
            var monuGuardaAppContext = _context.VisitasGuiadas.Include(p => p.Guia);
            return View(
                new VisitasGuiadasListViewModel
                {
                    VisitasGuiadas = _context.VisitasGuiadas.Where(p => name == null || p.Guia.Nome.Contains(name) || p.Nome.Contains(name))
                        .OrderBy(p => p.Guia.Nome)
                        .OrderBy(p => p.Nome)
                        .Skip((page - 1) * pagination.PageSize)
                        .Take(pagination.PageSize).Include(p => p.Guia),
                    Pagination = pagination,
                    SearchName = name
                }
            ) ;
        }

        // GET: VisitasGuiadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitasGuiadas = await _context.VisitasGuiadas
                .Include(v => v.Guia)
                .FirstOrDefaultAsync(m => m.VisitasGuiadasId == id);
            if (visitasGuiadas == null)
            {
                return NotFound();
            }

            return View(visitasGuiadas);
        }
        [Authorize(Roles = "Admin, Guia")]
        // GET: VisitasGuiadas/Create
        public IActionResult Create()
        {
            ViewData["GuiaId"] = new SelectList(_context.Guia, "GuiaId", "Nome");
            return View();
        }

        // POST: VisitasGuiadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisitasGuiadasId,GuiaId,Nome,DatadaVisita,Descricao,NMaxPessoas,Completo")] VisitasGuiadas visitasGuiadas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitasGuiadas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuiaId"] = new SelectList(_context.Guia, "GuiaId", "Nome", visitasGuiadas.GuiaId);
            return View(visitasGuiadas);
        }
        [Authorize(Roles = "Admin, Guia")]
        // GET: VisitasGuiadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitasGuiadas = await _context.VisitasGuiadas.FindAsync(id);
            if (visitasGuiadas == null)
            {
                return NotFound();
            }
            ViewData["GuiaId"] = new SelectList(_context.Guia, "GuiaId", "Nome", visitasGuiadas.GuiaId);
            return View(visitasGuiadas);
        }

        // POST: VisitasGuiadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisitasGuiadasId,GuiaId,Nome,DatadaVisita,Descricao,NMaxPessoas,Completo")] VisitasGuiadas visitasGuiadas)
        {
            if (id != visitasGuiadas.VisitasGuiadasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitasGuiadas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitasGuiadasExists(visitasGuiadas.VisitasGuiadasId))
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
            ViewData["GuiaId"] = new SelectList(_context.Guia, "GuiaId", "Nome", visitasGuiadas.GuiaId);
            return View(visitasGuiadas);
        }

        // GET: VisitasGuiadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitasGuiadas = await _context.VisitasGuiadas
                .Include(v => v.Guia)
                .FirstOrDefaultAsync(m => m.VisitasGuiadasId == id);
            if (visitasGuiadas == null)
            {
                return NotFound();
            }

            return View(visitasGuiadas);
        }

        // POST: VisitasGuiadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitasGuiadas = await _context.VisitasGuiadas.FindAsync(id);
            _context.VisitasGuiadas.Remove(visitasGuiadas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitasGuiadasExists(int id)
        {
            return _context.VisitasGuiadas.Any(e => e.VisitasGuiadasId == id);
        }
    }
}
