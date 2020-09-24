using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionStageEquipe7.Areas.Stages.Models;
using GestionStageEquipe7.Data;

namespace GestionStageEquipe7.Areas.Stages.Controllers
{
    [Area("Stages")]
    public class EmployeurMissionEmployeursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeurMissionEmployeursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stages/EmployeurMissionEmployeurs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeurMissionEmployeur.Include(e => e.Employeurs).Include(e => e.MissionsEmployeur);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Stages/EmployeurMissionEmployeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeurMissionEmployeur = await _context.EmployeurMissionEmployeur
                .Include(e => e.Employeurs)
                .Include(e => e.MissionsEmployeur)
                .FirstOrDefaultAsync(m => m.EmployeurMissionEmployeurId == id);
            if (employeurMissionEmployeur == null)
            {
                return NotFound();
            }

            return View(employeurMissionEmployeur);
        }

        // GET: Stages/EmployeurMissionEmployeurs/Create
        public IActionResult Create(Guid Id)
        {
            ViewData["EmployeurId"] = Id;  
            ViewData["MissionEmployeurId"] = new SelectList(_context.MissionEmployeur, "MissionEmployeurId", "DescriptionMissionEmployeur");
            return View();
        }

        // POST: Stages/EmployeurMissionEmployeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeurMissionEmployeurId,EmployeurId,MissionEmployeurId")] EmployeurMissionEmployeur employeurMissionEmployeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeurMissionEmployeur);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "Employeurs", new { id = employeurMissionEmployeur.EmployeurId } );
            }
            ViewData["EmployeurId"] = new SelectList(_context.Employeur, "EmployeurId", "EmployeurId", employeurMissionEmployeur.EmployeurId);
            ViewData["MissionEmployeurId"] = new SelectList(_context.MissionEmployeur, "MissionEmployeurId", "DescriptionMissionEmployeur", employeurMissionEmployeur.MissionEmployeurId);
            return View(employeurMissionEmployeur);
        }

        // GET: Stages/EmployeurMissionEmployeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeurMissionEmployeur = await _context.EmployeurMissionEmployeur.FindAsync(id);
            if (employeurMissionEmployeur == null)
            {
                return NotFound();
            }
            ViewData["EmployeurId"] = new SelectList(_context.Employeur, "EmployeurId", "EmployeurId", employeurMissionEmployeur.EmployeurId);
            ViewData["MissionEmployeurId"] = new SelectList(_context.MissionEmployeur, "MissionEmployeurId", "DescriptionMissionEmployeur", employeurMissionEmployeur.MissionEmployeurId);
            return View(employeurMissionEmployeur);
        }

        // POST: Stages/EmployeurMissionEmployeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeurMissionEmployeurId,EmployeurId,MissionEmployeurId")] EmployeurMissionEmployeur employeurMissionEmployeur)
        {
            if (id != employeurMissionEmployeur.EmployeurMissionEmployeurId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeurMissionEmployeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeurMissionEmployeurExists(employeurMissionEmployeur.EmployeurMissionEmployeurId))
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
            ViewData["EmployeurId"] = new SelectList(_context.Employeur, "EmployeurId", "EmployeurId", employeurMissionEmployeur.EmployeurId);
            ViewData["MissionEmployeurId"] = new SelectList(_context.MissionEmployeur, "MissionEmployeurId", "DescriptionMissionEmployeur", employeurMissionEmployeur.MissionEmployeurId);
            return View(employeurMissionEmployeur);
        }

        // GET: Stages/EmployeurMissionEmployeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeurMissionEmployeur = await _context.EmployeurMissionEmployeur
                .Include(e => e.Employeurs)
                .Include(e => e.MissionsEmployeur)
                .FirstOrDefaultAsync(m => m.EmployeurMissionEmployeurId == id);
            if (employeurMissionEmployeur == null)
            {
                return NotFound();
            }

            return View(employeurMissionEmployeur);
        }

        // POST: Stages/EmployeurMissionEmployeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeurMissionEmployeur = await _context.EmployeurMissionEmployeur.FindAsync(id);
            _context.EmployeurMissionEmployeur.Remove(employeurMissionEmployeur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeurMissionEmployeurExists(int id)
        {
            return _context.EmployeurMissionEmployeur.Any(e => e.EmployeurMissionEmployeurId == id);
        }
    }
}
