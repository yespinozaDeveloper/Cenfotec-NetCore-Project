using System;
using System.Collections.Generic;

namespace WebAPI.Infrastructure.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public long PkCategory { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
