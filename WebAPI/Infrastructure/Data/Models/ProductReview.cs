using System;
using System.Collections.Generic;

namespace WebAPI.Infrastructure.Data.Models
{
    public partial class ProductReview
    {
        public long PkProductReview { get; set; }
        public long FkProduct { get; set; }
        public long FkUser { get; set; }
        public string Detail { get; set; }
        public bool? Active { get; set; }

        public virtual Product FkProductNavigation { get; set; }
        public virtual User FkUserNavigation { get; set; }
    }
}
