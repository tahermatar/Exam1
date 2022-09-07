using System;
using System.Collections.Generic;

#nullable disable

namespace Exam1.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public int? SubcategoryId { get; set; }
        public string Name { get; set; }

        public virtual Subcategory Subcategory { get; set; }
    }
}
