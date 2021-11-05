﻿namespace PrimerProyectoClubDeportivoPA2.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PrimerProyectoClubDeportivoPA2.Web.Data;
    using PrimerProyectoClubDeportivoPA2.Web.Data.Entities;
    using PrimerProyectoClubDeportivoPA2.Web.Helpers;
    using PrimerProyectoClubDeportivoPA2.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;
    
    [Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> Details(int? id)
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

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facility = await this.dataContext.Facilities.FirstOrDefaultAsync(p => p.Id == id);
            if (facility == null)
            {
                return NotFound();
            }
            var model = new FacilityViewModel
            {
                Id = facility.Id,
                Code = facility.Code,
                Name = facility.Name,
                Description = facility.Description,
                ImageUrl = facility.ImageUrl
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FacilityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var facility = new Facility
                {
                    Id = model.Id,
                    Code = model.Code,
                    Name = model.Name,
                    Description = model.Description,
                    ImageUrl = (model.ImageFile != null ? await imageHelper.UploadImageAsync(model.ImageFile, model.Name, "facilities") : model.ImageUrl)
                };
                
                this.dataContext.Update(facility);
                await this.dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }



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
