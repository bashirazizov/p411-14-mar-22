using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vesper.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<ProjectToCategory> ProjectToCategories { get; set; }

    }
}
