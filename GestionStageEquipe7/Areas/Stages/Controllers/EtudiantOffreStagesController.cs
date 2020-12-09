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
    [Authorize(Roles = "Administrateur, Etudiant")]
    public class EtudiantOffreStagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EtudiantOffreStagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stages/EtudiantOffreStages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EtudiantOffreStage.Include(e => e.ApplicationUser).Include(e => e.OffresStage);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Stages/EtudiantOffreStages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiantOffreStage = await _context.EtudiantOffreStage
                .Include(e => e.ApplicationUser)
                .Include(e => e.OffresStage)
                .FirstOrDefaultAsync(m => m.OffresStageEtudiantId == id);
            if (etudiantOffreStage == null)
            {
                return NotFound();
            }

            return View(etudiantOffreStage);
        }

        // GET: Stages/EtudiantOffreStages/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["OffreStageId"] = new SelectList(_context.OffresStage, "OffreStageId", "DescriptionOffreStage");
            return View();
        }

        // POST: Stages/EtudiantOffreStages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OffresStageEtudiantId,Id,OffreStageId,DateCandidature,Actif")] EtudiantOffreStage etudiantOffreStage)
        {

            if (ModelState.IsValid)
            {
                etudiantOffreStage.OffresStageEtudiantId = Guid.NewGuid();
                _context.Add(etudiantOffreStage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", etudiantOffreStage.Id);
            ViewData["OffreStageId"] = new SelectList(_context.OffresStage, "OffreStageId", "DescriptionOffreStage", etudiantOffreStage.OffreStageId);
            return View(etudiantOffreStage);
        }

        // GET: Stages/EtudiantOffreStages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiantOffreStage = await _context.EtudiantOffreStage.FindAsync(id);
            if (etudiantOffreStage == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", etudiantOffreStage.Id);
            ViewData["OffreStageId"] = new SelectList(_context.OffresStage, "OffreStageId", "DescriptionOffreStage", etudiantOffreStage.OffreStageId);
            return View(etudiantOffreStage);
        }

        // POST: Stages/EtudiantOffreStages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OffresStageEtudiantId,Id,OffreStageId,DateCandidature,Actif")] EtudiantOffreStage etudiantOffreStage)
        {
            if (id != etudiantOffreStage.OffresStageEtudiantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiantOffreStage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantOffreStageExists(etudiantOffreStage.OffresStageEtudiantId))
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
            ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", etudiantOffreStage.Id);
            ViewData["OffreStageId"] = new SelectList(_context.OffresStage, "OffreStageId", "DescriptionOffreStage", etudiantOffreStage.OffreStageId);
            return View(etudiantOffreStage);
        }

        // GET: Stages/EtudiantOffreStages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var etudiantOffreStage = await _context.EtudiantOffreStage
                .Include(e => e.ApplicationUser)
                .Include(e => e.OffresStage)
                .FirstOrDefaultAsync(m => m.OffresStageEtudiantId == id);
            if (etudiantOffreStage == null)
            {
                return NotFound();
            }

            return View(etudiantOffreStage);
        }

        // POST: Stages/EtudiantOffreStages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var etudiantOffreStage = await _context.EtudiantOffreStage.FindAsync(id);
            _context.EtudiantOffreStage.Remove(etudiantOffreStage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantOffreStageExists(Guid id)
        {
            return _context.EtudiantOffreStage.Any(e => e.OffresStageEtudiantId == id);
        }
    }
}
