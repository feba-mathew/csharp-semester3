using System;
using System.Collections.Generic;

namespace WebsiteProject1
{
    public partial class Users
    {
        public Users()
        {
            UserClasses = new HashSet<UserClasses>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public virtual ICollection<UserClasses> UserClasses { get; set; }
    }
}
