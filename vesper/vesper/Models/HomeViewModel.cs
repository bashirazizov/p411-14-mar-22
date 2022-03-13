using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vesper.Models
{
    public class HomeViewModel
    {
        public Banner Banner { get; set; }
        public HomeAboutSection HomeAboutSection { get; set; }
        public List<Partner> Partners { get; set; }
        public List<Stat> Stats { get; set; }
        public List<Project> Projects { get; set; }
        public List<Category> Categories { get; set; }
        public List<Testimonial> Testimonials { get; set; }
    }
}
