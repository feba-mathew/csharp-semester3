using System;
using System.Collections.Generic;

namespace WebsiteProject1
{
    public partial class UserClasses
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }

        public virtual ClassMaster Class { get; set; }
        public virtual Users User { get; set; }
    }
}
