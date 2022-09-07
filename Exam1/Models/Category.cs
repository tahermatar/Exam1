using System;
using System.Collections.Generic;

#nullable disable

namespace Exam1.Models
{
    public partial class Category
    {
        public Category()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        public int Id { get; set; }
        public int? Subcategory { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
