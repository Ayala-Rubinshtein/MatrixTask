using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class School
    {
        public School()
        {
            Lessons = new HashSet<Lesson>();
            Students = new HashSet<Student>();
            Tests = new HashSet<Test>();
        }

        public int Idschool { get; set; }
        public string Name { get; set; }
        public int? Idcontact { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public int? Idaddress { get; set; }
        public string Contact { get; set; }
        public string ContactName { get; set; }
        public string ContactTel { get; set; }
        public string ContactMail { get; set; }

        public virtual Address IdaddressNavigation { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
