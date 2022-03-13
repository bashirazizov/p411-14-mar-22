using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vesper.DAL;
using vesper.Models;

namespace vesper.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class TestimonialsController : Controller
    {
        private readonly VesperDbContext db;
        public TestimonialsController(VesperDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Testimonials.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Testimonials");
            Testimonial testi = await db.Testimonials.FindAsync(id);
            if (testi == null) return RedirectToAction("Index", "Testimonials");
            return View(testi);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Testimonial testimonial)
        {
            if (!ModelState.IsValid) return View();
            Testimonial duplicate = await db.Testimonials.FirstOrDefaultAsync(x=>x.Text == testimonial.Text);
            if (duplicate != null)
            {
                ModelState.AddModelError("Text", "Text unique olmalidir.");
                return View();
            }
            await db.Testimonials.AddAsync(testimonial);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Testimonials");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Testimonials");
            Testimonial testi = await db.Testimonials.FindAsync(id);
            if (testi == null) return RedirectToAction("Index", "Testimonials");
            return View(testi);
        }

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Testimonials"); 
            Testimonial testiToDelete = await db.Testimonials.FindAsync(id);
            if (testiToDelete == null) return RedirectToAction("Index", "Testimonials");
            db.Testimonials.Remove(testiToDelete);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Testimonials");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Testimonials");
            Testimonial testi = await db.Testimonials.FindAsync(id);
            if (testi == null) return RedirectToAction("Index", "Testimonials");
            return View(testi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Testimonial testimonial)
        {
            if (!ModelState.IsValid) return View();
            db.Testimonials.Update(testimonial);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Testimonials");
        }
    }
}
