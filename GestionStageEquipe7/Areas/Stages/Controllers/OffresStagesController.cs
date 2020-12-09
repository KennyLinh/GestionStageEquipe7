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
    [Authorize(Roles = "Administrateur, Etudiant, Employeur")]
    public class OffresStagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OffresStagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stages/OffresStages
        public async Task<IActionResult> Index()
        {
            return View(await _context.OffresStage.ToListAsync());
        }

        // GET: Stages/OffresStages/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offresStage = await _context.OffresStage
                .FirstOrDefaultAsync(m => m.OffreStageId == id);
            if (offresStage == null)
            {
                return NotFound();
            }

            return View(offresStage);
        }

        // GET: Stages/OffresStages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stages/OffresStages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OffreStageId,TitreOffreStage,DescriptionOffreStage,OffreStageDateDebut,OffreStageDateFin,Actif")] OffresStage offresStage)
        {
            if (ModelState.IsValid)
            {
                offresStage.OffreStageId = Guid.NewGuid();
                _context.Add(offresStage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(offresStage);
        }

        // GET: Stages/OffresStages/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offresStage = await _context.OffresStage.FindAsync(id);
            if (offresStage == null)
            {
                return NotFound();
            }
            return View(offresStage);
        }

        // POST: Stages/OffresStages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OffreStageId,TitreOffreStage,DescriptionOffreStage,OffreStageDateDebut,OffreStageDateFin,Actif")] OffresStage offresStage)
        {
            if (id != offresStage.OffreStageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offresStage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OffresStageExists(offresStage.OffreStageId))
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
            return View(offresStage);
        }

        // GET: Stages/OffresStages/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offresStage = await _context.OffresStage
                .FirstOrDefaultAsync(m => m.OffreStageId == id);
            if (offresStage == null)
            {
                return NotFound();
            }

            return View(offresStage);
        }

        // POST: Stages/OffresStages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var offresStage = await _context.OffresStage.FindAsync(id);
            _context.OffresStage.Remove(offresStage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OffresStageExists(Guid id)
        {
            return _context.OffresStage.Any(e => e.OffreStageId == id);
        }
    }
}
