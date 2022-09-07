using System;
using System.Collections.Generic;

#nullable disable

namespace Exam1.Models
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public int? Category { get; set; }
        public string Name { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
