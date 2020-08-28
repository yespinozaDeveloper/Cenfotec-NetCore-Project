using System;
using System.Collections.Generic;

namespace WebAPI.Infrastructure.Data.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
            ProductReview = new HashSet<ProductReview>();
        }

        public long PkProduct { get; set; }
        public long FkCategory { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public bool? Active { get; set; }

        public virtual Category FkCategoryNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<ProductReview> ProductReview { get; set; }
    }
}
