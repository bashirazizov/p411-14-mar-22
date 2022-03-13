using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vesper.Models
{
    public class Stat : BaseEntity
    {
        public string Icon { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }
}
