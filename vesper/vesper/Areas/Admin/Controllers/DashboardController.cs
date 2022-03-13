using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vesper.Areas.Admin.Models;
using vesper.DAL;

namespace vesper.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin")]
    public class DashboardController : Controller
    {
        private readonly VesperDbContext db;
        public DashboardController(VesperDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            DashboardViewModel dvm = new DashboardViewModel();
            dvm.TestimonialCount = await db.Testimonials.CountAsync();
            dvm.PartnerCount = await db.Partners.CountAsync();
            return View(dvm);
        }
    }
}
