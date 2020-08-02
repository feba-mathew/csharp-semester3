using System;
using System.Collections.Generic;

namespace WebsiteProject1
{
    public partial class ClassMaster
    {
        public ClassMaster()
        {
            UserClasses = new HashSet<UserClasses>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public double ClassPrice { get; set; }
        public int ClassSessions { get; set; }

        public virtual ICollection<UserClasses> UserClasses { get; set; }
    }
}
