using System;
using System.Collections.Generic;

namespace WebAPI.Infrastructure.Data.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public long PkOrder { get; set; }
        public DateTime Date { get; set; }
        public long? FkUser { get; set; }
        public int FkStatus { get; set; }
        public bool? Active { get; set; }

        public virtual Status FkStatusNavigation { get; set; }
        public virtual User FkUserNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
