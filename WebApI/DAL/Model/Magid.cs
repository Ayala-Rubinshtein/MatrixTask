using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class Magid
    {
        public Magid()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int Idmagid { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
