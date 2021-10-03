using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrimerProyectoClubDeportivoPA2.Web.Data;
using PrimerProyectoClubDeportivoPA2.Web.Data.Entities;

namespace PrimerProyectoClubDeportivoPA2.Web.Controllers
{
    public class AdditionalSkillsController : Controller
    {
        private readonly DataContext _context;

        public AdditionalSkillsController(DataContext context)
        {
            _context = context;
        }

        // GET: AdditionalSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdditionalSkills.ToListAsync());
        }

        // GET: AdditionalSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var additionalSkill = await _context.AdditionalSkills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (additionalSkill == null)
            {
                return NotFound();
            }

            return View(additionalSkill);
        }

        // GET: AdditionalSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdditionalSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AdditionalSkill additionalSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(additionalSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(additionalSkill);
        }

        // GET: AdditionalSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var additionalSkill = await _context.AdditionalSkills.FindAsync(id);
            if (additionalSkill == null)
            {
                return NotFound();
            }
            return View(additionalSkill);
        }

        // POST: AdditionalSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AdditionalSkill additionalSkill)
        {
            if (id != additionalSkill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(additionalSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdditionalSkillExists(additionalSkill.Id))
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
            return View(additionalSkill);
        }

        // GET: AdditionalSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var additionalSkill = await _context.AdditionalSkills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (additionalSkill == null)
            {
                return NotFound();
            }

            return View(additionalSkill);
        }

        // POST: AdditionalSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var additionalSkill = await _context.AdditionalSkills.FindAsync(id);
            _context.AdditionalSkills.Remove(additionalSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdditionalSkillExists(int id)
        {
            return _context.AdditionalSkills.Any(e => e.Id == id);
        }
    }
}
