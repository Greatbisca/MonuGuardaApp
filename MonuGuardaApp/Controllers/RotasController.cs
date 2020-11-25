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
    public class RotasController : Controller
    {
        private readonly MonuGuardaAppContext _context;

        public RotasController(MonuGuardaAppContext context)
        {
            _context = context;
        }

        // GET: Rotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rotas.ToListAsync());
        }

        // GET: Rotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotas = await _context.Rotas
                .FirstOrDefaultAsync(m => m.RotasId == id);
            if (rotas == null)
            {
                return NotFound();
            }

            return View(rotas);
        }

        // GET: Rotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RotasId,Nome,Morada,Telemovel")] Rotas rotas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rotas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rotas);
        }

        // GET: Rotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotas = await _context.Rotas.FindAsync(id);
            if (rotas == null)
            {
                return NotFound();
            }
            return View(rotas);
        }

        // POST: Rotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RotasId,Nome,Morada,Telemovel")] Rotas rotas)
        {
            if (id != rotas.RotasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rotas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RotasExists(rotas.RotasId))
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
            return View(rotas);
        }

        // GET: Rotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rotas = await _context.Rotas
                .FirstOrDefaultAsync(m => m.RotasId == id);
            if (rotas == null)
            {
                return NotFound();
            }

            return View(rotas);
        }

        // POST: Rotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rotas = await _context.Rotas.FindAsync(id);
            _context.Rotas.Remove(rotas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RotasExists(int id)
        {
            return _context.Rotas.Any(e => e.RotasId == id);
        }
    }
}
