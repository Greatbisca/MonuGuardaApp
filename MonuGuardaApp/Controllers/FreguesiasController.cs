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
    public class FreguesiasController : Controller
    {
        private readonly MonuGuardaAppContext _context;

        public FreguesiasController(MonuGuardaAppContext context)
        {
            _context = context;
        }

        // GET: Freguesias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Freguesia.ToListAsync());
        }

        // GET: Freguesias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freguesia = await _context.Freguesia
                .FirstOrDefaultAsync(m => m.FreguesiaId == id);
            if (freguesia == null)
            {
                return NotFound();
            }

            return View(freguesia);
        }

        // GET: Freguesias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Freguesias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FreguesiaId,Nome")] Freguesia freguesia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freguesia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(freguesia);
        }

        // GET: Freguesias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freguesia = await _context.Freguesia.FindAsync(id);
            if (freguesia == null)
            {
                return NotFound();
            }
            return View(freguesia);
        }

        // POST: Freguesias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FreguesiaId,Nome")] Freguesia freguesia)
        {
            if (id != freguesia.FreguesiaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freguesia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreguesiaExists(freguesia.FreguesiaId))
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
            return View(freguesia);
        }

        // GET: Freguesias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var freguesia = await _context.Freguesia
                .FirstOrDefaultAsync(m => m.FreguesiaId == id);
            if (freguesia == null)
            {
                return NotFound();
            }

            return View(freguesia);
        }

        // POST: Freguesias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var freguesia = await _context.Freguesia.FindAsync(id);
            _context.Freguesia.Remove(freguesia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FreguesiaExists(int id)
        {
            return _context.Freguesia.Any(e => e.FreguesiaId == id);
        }
    }
}
