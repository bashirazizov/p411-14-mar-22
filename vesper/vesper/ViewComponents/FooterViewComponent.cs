using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vesper.DAL;
using vesper.Models;

namespace vesper.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly VesperDbContext db;
        public FooterViewComponent(VesperDbContext _db)
        {
            db = _db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterViewModel fvm = new FooterViewModel();

            fvm.SocialLinks = await db.SocialLinks.ToListAsync();
            fvm.FooterText = "Cras fermentum odio eu feugiat. Justo eget magna fermentum iaculis eu non diam phasellus. Scelerisque felis imperdiet proin fermentum leo. Amet volutpat consequat mauris nunc congue.";

            return View(fvm);
        }
    }
}
