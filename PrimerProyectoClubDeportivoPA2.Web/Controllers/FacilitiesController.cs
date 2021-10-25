namespace PrimerProyectoClubDeportivoPA2.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PrimerProyectoClubDeportivoPA2.Web.Data;
    using PrimerProyectoClubDeportivoPA2.Web.Data.Entities;
    using PrimerProyectoClubDeportivoPA2.Web.Helpers;
    using PrimerProyectoClubDeportivoPA2.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;
    public class FacilitiesController : Controller
    {
        private readonly DataContext dataContext;
        private readonly IImageHelper imageHelper;


        public FacilitiesController(DataContext dataContext,
            IImageHelper imageHelper)
        {
            this.dataContext = dataContext;
            this.imageHelper = imageHelper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.dataContext.Facilities.ToListAsync());
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var facility = await dataContext.Facilities
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (facility == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(facility);
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FacilityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var facility = new Facility
                {
                    Name = model.Name,
                    Code = model.Code,
                    Description = model.Description,
                    ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(
                        model.ImageFile,
                        model.Name,
                        "facilities") : string.Empty)
                };
                this.dataContext.Add(facility);
                await this.dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await dataContext.Facilities.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }
            return View(facility);
        }

        // POST: Facilities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Name,Description")] Facility facility)
        {
            if (id != facility.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dataContext.Update(facility);
                    await dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilityExists(facility.Id))
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
            return View(facility);
        }

        // GET: Facilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await dataContext.Facilities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // POST: Facilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facility = await dataContext.Facilities.FindAsync(id);
            dataContext.Facilities.Remove(facility);
            await dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilityExists(int id)
        {
            return dataContext.Facilities.Any(e => e.Id == id);
        }
    }
}
