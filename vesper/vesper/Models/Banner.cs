using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vesper.Models
{
    public class Banner : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string BtnText { get; set; }
        [Required]
        public string BtnLink { get; set; }
        [Required]
        public string Img { get; set; }
    }
}
