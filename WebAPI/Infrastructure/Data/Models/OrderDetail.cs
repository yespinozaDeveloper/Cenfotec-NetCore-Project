using System;
using System.Collections.Generic;

namespace WebAPI.Infrastructure.Data.Models
{
    public partial class OrderDetail
    {
        public long PkOrderDetail { get; set; }
        public long FkOrder { get; set; }
        public long? FkProduct { get; set; }

        public virtual Order FkOrderNavigation { get; set; }
        public virtual Product FkProductNavigation { get; set; }
    }
}
