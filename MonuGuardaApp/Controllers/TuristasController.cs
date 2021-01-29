using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MonuGuardaApp.Data;
using MonuGuardaApp.Models;

namespace MonuGuardaApp.Controllers
{

    public class TuristasController : Controller
    {
        private readonly MonuGuardaAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TuristasController(MonuGuardaAppContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        // GET: Turistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turista.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        // GET: Turistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista
                .FirstOrDefaultAsync(m => m.TuristaId == id);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        // GET: Turistas/Create
        public IActionResult Register()
        {
            return View();
        }

    
        // POST: Turistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterTuristaViewModel turistaInfo)
        {
            if (!ModelState.IsValid) { 
                return View(turistaInfo); 
            }
            string username = turistaInfo.Email;

            IdentityUser user = await _userManager.FindByNameAsync(username); 

            if (user != null) 
            { 
                ModelState.AddModelError("Email", "Já foi criada uma conta com este email."); 
                return View(turistaInfo); 
            }
            user = new IdentityUser(username); 
            await _userManager.CreateAsync(user, turistaInfo.Password); 
            await _userManager.AddToRoleAsync(user, "Turista"); 

            Turista turista = new Turista
            {
                Nome = turistaInfo.Nome, 
                Telemovel = turistaInfo.Telemovel, 
                Morada = turistaInfo.Morada,
                NIF = turistaInfo.NIF, 
                Email = turistaInfo.Email 
            }; 
            _context.Add(turista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        [Authorize(Roles = "Turista")]
        public async Task<IActionResult> EditPersonalData()
        {
            string email = User.Identity.Name;

            var turista = await _context.Turista.SingleOrDefaultAsync(c => c.Email == email);
            if (turista == null)
            {
                return NotFound();
            }

            EditLoggedInTuristaViewModel turistaInfo = new EditLoggedInTuristaViewModel
            {
                Nome =turista.Nome,
                Email = turista.Email,
                NIF = turista.NIF,
                Morada = turista.Morada
            };

            return View(turistaInfo);
        }

        // POST: Customers/EditLoggedInCustomerViewModel
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Turista")]
        public async Task<IActionResult> EditPersonalData(EditLoggedInTuristaViewModel turista)
        {
            if (!ModelState.IsValid)
            {
                return View(turista);
            }

            string email = User.Identity.Name;

            var turistaLoggedin = await _context.Turista.SingleOrDefaultAsync(c => c.Email == email);
            if (turistaLoggedin == null)
            {
                return NotFound();
            }

            turistaLoggedin.Nome = turista.Nome;

            try
            {
                _context.Update(turistaLoggedin);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //todo: show error message

                throw;
            }
            return RedirectToAction(nameof(Index), "Home");
        }
        // GET: Turistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista.FindAsync(id);
            if (turista == null)
            {
                return NotFound();
            }
            return View(turista);
        }

        // POST: Turistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TuristaId,Nome,Morada,NIF,Email,Telemovel,DataNascimento")] Turista turista)
        {
            if (id != turista.TuristaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuristaExists(turista.TuristaId))
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
            return View(turista);
        }

        // GET: Turistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turista = await _context.Turista
                .FirstOrDefaultAsync(m => m.TuristaId == id);
            if (turista == null)
            {
                return NotFound();
            }

            return View(turista);
        }

        // POST: Turistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turista = await _context.Turista.FindAsync(id);
            _context.Turista.Remove(turista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TuristaExists(int id)
        {
            return _context.Turista.Any(e => e.TuristaId == id);
        }
    }
}
