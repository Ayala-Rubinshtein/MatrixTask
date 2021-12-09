using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class Student
    {
        public Student()
        {
            TestOfStudents = new HashSet<TestOfStudent>();
        }

        public int Idstudent { get; set; }
        public string Id { get; set; }
        public int? TypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public int? Idaddress { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int? Idcreater { get; set; }
        public string DateCreate { get; set; }
        public int? Idschool { get; set; }

        public virtual Address IdaddressNavigation { get; set; }
        public virtual User IdcreaterNavigation { get; set; }
        public virtual School IdschoolNavigation { get; set; }
        public virtual ICollection<TestOfStudent> TestOfStudents { get; set; }
    }
}
