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
    public class PermitsController : Controller
    {
        private readonly DataContext _context;

        public PermitsController(DataContext context)
        {
            _context = context;
        }

        // GET: Permits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Permits.ToListAsync());
        }

        // GET: Permits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permit = await _context.Permits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permit == null)
            {
                return NotFound();
            }

            return View(permit);
        }

        // GET: Permits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Permits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Permit permit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permit);
        }

        // GET: Permits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permit = await _context.Permits.FindAsync(id);
            if (permit == null)
            {
                return NotFound();
            }
            return View(permit);
        }

        // POST: Permits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Permit permit)
        {
            if (id != permit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermitExists(permit.Id))
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
            return View(permit);
        }

        // GET: Permits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permit = await _context.Permits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permit == null)
            {
                return NotFound();
            }

            return View(permit);
        }

        // POST: Permits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permit = await _context.Permits.FindAsync(id);
            _context.Permits.Remove(permit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermitExists(int id)
        {
            return _context.Permits.Any(e => e.Id == id);
        }
    }
}
