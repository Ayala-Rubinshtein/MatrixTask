using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class Lesson
    {
        public int Idlesson { get; set; }
        public string Name { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public double? Len { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Idschool { get; set; }
        public int? Idmagid { get; set; }
        public int? Number { get; set; }

        public virtual Magid Idmag { get; set; }
        public virtual School IdschoolNavigation { get; set; }
    }
}
