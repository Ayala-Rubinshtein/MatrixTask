using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class Address
    {
        public Address()
        {
            Clients = new HashSet<Client>();
            Schools = new HashSet<School>();
            Students = new HashSet<Student>();
            Users = new HashSet<User>();
        }

        public int Idadress { get; set; }
        public int? CityId { get; set; }
        public int? StreetId { get; set; }
        public int? HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public int? PoBox { get; set; }
        public int? ZipCode { get; set; }

        public virtual City City { get; set; }
        public virtual Street Street { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<School> Schools { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
