using System;
using System.Collections.Generic;

namespace WebAPI.Infrastructure.Data.Models
{
    public partial class Product
    {
        public long PkProduct { get; set; }
        public long FkCategory { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public bool? Active { get; set; }

        public virtual Category FkCategoryNavigation { get; set; }
    }
}
