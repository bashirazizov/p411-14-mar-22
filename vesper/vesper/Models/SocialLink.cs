using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vesper.Models
{
    public class SocialLink : BaseEntity
    {
        public string Icon { get; set; }
        public string Link { get; set; }
    }
}
