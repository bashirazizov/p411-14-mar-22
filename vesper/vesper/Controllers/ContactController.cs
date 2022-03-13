using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vesper.DAL;
using vesper.Models;

namespace vesper.Controllers
{
    public class ContactController : Controller
    {
        private readonly VesperDbContext db;

        public ContactController(VesperDbContext _db)
        {
            db = _db;
        }

        [HttpPost]
        public async Task<IActionResult> Send(Message message)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Home");

            await db.Messages.AddAsync(message);
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
