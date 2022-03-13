using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using vesper.DAL;

namespace vesper.ViewComponents
{
    public class TestimonialsViewComponent : ViewComponent
    {
        private readonly VesperDbContext db;
        public TestimonialsViewComponent(VesperDbContext _db)
        {
            db = _db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await Task.FromResult(db.Testimonials.ToList()));
        }
    }
}
