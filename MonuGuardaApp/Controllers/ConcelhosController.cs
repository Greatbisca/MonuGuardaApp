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
    public class ConcelhosController : Controller
    {
        private readonly MonuGuardaAppContext _context;

        public ConcelhosController(MonuGuardaAppContext context)
        {
            _context = context;
        }

        // GET: Concelhos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Concelho.ToListAsync());
        }

        // GET: Concelhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concelho = await _context.Concelho
                .FirstOrDefaultAsync(m => m.ConcelhoId == id);
            if (concelho == null)
            {
                return NotFound();
            }

            return View(concelho);
        }

        // GET: Concelhos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concelhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConcelhoId,Nome")] Concelho concelho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concelho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concelho);
        }

        // GET: Concelhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concelho = await _context.Concelho.FindAsync(id);
            if (concelho == null)
            {
                return NotFound();
            }
            return View(concelho);
        }

        // POST: Concelhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConcelhoId,Nome")] Concelho concelho)
        {
            if (id != concelho.ConcelhoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concelho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcelhoExists(concelho.ConcelhoId))
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
            return View(concelho);
        }

        // GET: Concelhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concelho = await _context.Concelho
                .FirstOrDefaultAsync(m => m.ConcelhoId == id);
            if (concelho == null)
            {
                return NotFound();
            }

            return View(concelho);
        }

        // POST: Concelhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concelho = await _context.Concelho.FindAsync(id);
            _context.Concelho.Remove(concelho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcelhoExists(int id)
        {
            return _context.Concelho.Any(e => e.ConcelhoId == id);
        }
    }
}
