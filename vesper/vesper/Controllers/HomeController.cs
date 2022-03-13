using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vesper.DAL;
using vesper.Models;

namespace vesper.Controllers
{
    public class HomeController : Controller
    {
        private readonly VesperDbContext db;

        public HomeController(VesperDbContext _db)
        {
            db = _db;
        }

        public IActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel {
                Banner = db.Banners.FirstOrDefault(),
                Partners = db.Partners.ToList(),
                Stats = db.Stats.ToList(),
                HomeAboutSection = db.HomeAboutSections.FirstOrDefault(),
                Categories = db.Categories.ToList(),
                Projects = db.Projects.Include(x=>x.ProjectToCategories).Take(6).ToList()
            };

            return View(hvm);
        }
    }
}
