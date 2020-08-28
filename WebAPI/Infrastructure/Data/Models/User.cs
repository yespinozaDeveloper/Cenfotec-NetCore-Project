using System;
using System.Collections.Generic;

namespace WebAPI.Infrastructure.Data.Models
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
            ProductReview = new HashSet<ProductReview>();
            UserPassword = new HashSet<UserPassword>();
        }

        public long PkUser { get; set; }
        public string PersonalIdentification { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<ProductReview> ProductReview { get; set; }
        public virtual ICollection<UserPassword> UserPassword { get; set; }
    }
}
