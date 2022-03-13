using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vesper.Models;

namespace vesper.DAL
{
    public class VesperDbContext : IdentityDbContext<AppUser>
    {
        public VesperDbContext(DbContextOptions<VesperDbContext> options) : base(options)
        { }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<HomeAboutSection> HomeAboutSections { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProjectToCategory> ProjectToCategories { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
