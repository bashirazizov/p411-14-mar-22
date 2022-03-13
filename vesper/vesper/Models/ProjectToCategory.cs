using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vesper.Models
{
    public class ProjectToCategory : BaseEntity
    {
        public int CategoryId { get; set; }
        public int ProjectId { get; set; }
        public Category Category { get; set; }
        public Project Project { get; set; }
    }
}
