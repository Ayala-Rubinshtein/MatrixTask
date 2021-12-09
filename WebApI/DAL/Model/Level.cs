using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class Level
    {
        public Level()
        {
            Tests = new HashSet<Test>();
        }

        public int Idlevel { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
