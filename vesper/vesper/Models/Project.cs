using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vesper.Models
{
    public class Project : BaseEntity
    {

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Name { get; set; }

        public string Image { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Client { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string Url { get; set; }

        [Required(AllowEmptyStrings = false), MaxLength(300)]
        public string DetailedHeading { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string DetailedText { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public List<ProjectToCategory> ProjectToCategories { get; set; }
        public List<ProjectImage> ProjectImages { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [NotMapped]
        public IFormFile[] ImageList { get; set; }


    }
}
