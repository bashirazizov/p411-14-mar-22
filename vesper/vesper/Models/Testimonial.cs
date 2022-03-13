using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vesper.Models
{
    public class Testimonial : BaseEntity
    {
        [Display(Name = "Müəllif")]
        [Required(ErrorMessage = "Müəllifin adı daxil edilməlidir.", AllowEmptyStrings = false), MaxLength(100)]
        public string AuthorName { get; set; }

        [Display(Name = "Müəllifin Şəkli")]
        [MaxLength(1000)]
        public string AuthorImage { get; set; }

        [Display(Name = "Müəllifin Vəzifəsi")]
        [Required(AllowEmptyStrings = false), MaxLength(100)]
        public string AuthorOccupation { get; set; }

        [Display(Name = "Rəy")]
        [Required(AllowEmptyStrings = false)]
        public string Text { get; set; }

        public Testimonial(string AuthorName, string AuthorImage, string AuthorOccupation, string Text)
        {
            this.AuthorName = AuthorName;
            this.AuthorImage = AuthorImage;
            this.AuthorOccupation = AuthorOccupation;
            this.Text = Text;
        }

        public Testimonial()
        {

        }
    }
}
