using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionStageEquipe7.Areas.Stages.Models;
using GestionStageEquipe7.Data;
using Microsoft.AspNetCore.Authorization;

namespace GestionStageEquipe7.Areas.Stages.Controllers
{
    [Area("Stages")]
    [Authorize(Roles ="Administrateur, Etudiant")]
    public class EmployeursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeursController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: Stages/Employeurs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employeur.Include(e => e.TypeEmployeur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Stages/Employeurs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeur = await _context.Employeur
                .Include(e => e.TypeEmployeur)
                .FirstOrDefaultAsync(m => m.EmployeurId == id);
            if (employeur == null)
            {
                return NotFound();
            }

            return View(employeur);
        }

        // GET: Stages/Employeurs/Create
        public IActionResult Create()
        {
            ViewData["TypeEmployeurId"] = new SelectList(_context.TypeEmployeur, "TypeEmployeurId", "TypeEmployeurId");
            return View();
        }

        // POST: Stages/Employeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeurId,NomEmployeur,Actif,TypeEmployeurId")] Employeur employeur)
        {
            if (ModelState.IsValid)
            {
                employeur.EmployeurId = Guid.NewGuid();
                _context.Add(employeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeEmployeurId"] = new SelectList(_context.TypeEmployeur, "TypeEmployeurId", "TypeEmployeurId", employeur.TypeEmployeurId);
            return View(employeur);
        }

        // GET: Stages/Employeurs/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var employeur = await _context.Employeur.FindAsync(id);

            var employeur = _context.Employeur.Where(info => info.EmployeurId == id).Include("EmployeursMissionEmployeur.MissionsEmployeur").FirstOrDefault();

            if (employeur == null)
            {
                return NotFound();
            }
            ViewData["TypeEmployeurId"] = new SelectList(_context.TypeEmployeur, "TypeEmployeurId", "TypeEmployeurId", employeur.TypeEmployeurId);
            return View(employeur);
        }

        // POST: Stages/Employeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EmployeurId,NomEmployeur,Actif,TypeEmployeurId")] Employeur employeur)
        {
            if (id != employeur.EmployeurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeurExists(employeur.EmployeurId))
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
            ViewData["TypeEmployeurId"] = new SelectList(_context.TypeEmployeur, "TypeEmployeurId", "TypeEmployeurId", employeur.TypeEmployeurId);
            return View(employeur);
        }
        //
        // GET: Stages/Employeurs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeur = await _context.Employeur
                .Include(e => e.TypeEmployeur)
                .FirstOrDefaultAsync(m => m.EmployeurId == id);
            if (employeur == null)
            {
                return NotFound();
            }

            return View(employeur);
        }

        // POST: Stages/Employeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var employeur = await _context.Employeur.FindAsync(id);
            _context.Employeur.Remove(employeur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeurExists(Guid id)
        {
            return _context.Employeur.Any(e => e.EmployeurId == id);
        }
    }
}
