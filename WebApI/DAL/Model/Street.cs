using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class Street
    {
        public Street()
        {
            Addresses = new HashSet<Address>();
        }

        public int Idstreet { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
