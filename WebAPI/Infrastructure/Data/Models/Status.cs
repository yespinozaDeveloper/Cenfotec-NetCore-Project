using System;
using System.Collections.Generic;

namespace WebAPI.Infrastructure.Data.Models
{
    public partial class Status
    {
        public Status()
        {
            Order = new HashSet<Order>();
        }

        public int PkStatus { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
