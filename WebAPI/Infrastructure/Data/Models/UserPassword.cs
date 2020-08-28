using System;
using System.Collections.Generic;

namespace WebAPI.Infrastructure.Data.Models
{
    public partial class UserPassword
    {
        public long UserPassword1 { get; set; }
        public long FkUser { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool? Active { get; set; }

        public virtual User FkUserNavigation { get; set; }
    }
}
