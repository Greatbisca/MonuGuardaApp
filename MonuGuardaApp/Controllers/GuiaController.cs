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
    public class GuiaController : Controller
    {
        private MonuGuardaRepository repository;


        private readonly MonuGuardaAppContext _context;

        public GuiaController(MonuGuardaAppContext context)
        {
            _context = context;
        }

        public GuiaController(MonuGuardaRepository repository)
        {
            this.repository = repository;
        }

        // GET: Guias
        public async Task<IActionResult> Index(int page = 1)
        {
            var pagination = new PagingGuia
            {
                CurrentPage = page,
                PageSize = PagingGuia.DEFAULT_PAGE_SIZE,
                TotalItems = repository.Guia.Count()
            };

            return View(
                new GuiaListViewModel
                {
                    Guia = repository.Guia
                        .OrderBy(p => p.Nome)
                        .Skip((page - 1) * pagination.PageSize)
                        .Take(pagination.PageSize),
                    Pagination = pagination
                }
            );

            return View(await _context.Guia.ToListAsync());
        }

        // GET: Guias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guia = await _context.Guia
                .FirstOrDefaultAsync(m => m.GuiaId == id);
            if (guia == null)
            {
                return NotFound();
            }

            return View(guia);
        }

        // GET: Guias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GuiaId,Nome,Telemovel")] Guia guia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guia);
        }

        // GET: Guias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guia = await _context.Guia.FindAsync(id);
            if (guia == null)
            {
                return NotFound();
            }
            return View(guia);
        }

        // POST: Guias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GuiaId,Nome,Telemovel")] Guia guia)
        {
            if (id != guia.GuiaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuiaExists(guia.GuiaId))
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
            return View(guia);
        }

        // GET: Guias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guia = await _context.Guia
                .FirstOrDefaultAsync(m => m.GuiaId == id);
            if (guia == null)
            {
                return NotFound();
            }

            return View(guia);
        }

        // POST: Guias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guia = await _context.Guia.FindAsync(id);
            _context.Guia.Remove(guia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuiaExists(int id)
        {
            return _context.Guia.Any(e => e.GuiaId == id);
        }
    }

   
}
