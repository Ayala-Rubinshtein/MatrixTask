using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class User
    {
        public User()
        {
            Students = new HashSet<Student>();
            Tests = new HashSet<Test>();
        }

        public int Iduser { get; set; }
        public int? Tz { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? Idaddress { get; set; }
        public string VoiceSystemPhone { get; set; }
        public string VoiceSystemPassword { get; set; }
        public bool? IsPrivateServer { get; set; }

        public virtual Address IdaddressNavigation { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
