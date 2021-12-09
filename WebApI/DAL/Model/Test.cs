using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class Test
    {
        public Test()
        {
            Questions = new HashSet<Question>();
            TestOfStudents = new HashSet<TestOfStudent>();
        }

        public int Idtest { get; set; }
        public int? Idschool { get; set; }
        public string Name { get; set; }
        public DateTime? BeginDate { get; set; }
        public TimeSpan? BeginTime { get; set; }
        public DateTime? FinishDate { get; set; }
        public TimeSpan? FinishTime { get; set; }
        public int? NumberOfQuestions { get; set; }
        public int? Idlevel { get; set; }
        public int? Idcreater { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Folder { get; set; }
        public string VoiceSystemPhone { get; set; }

        public virtual User IdcreaterNavigation { get; set; }
        public virtual Level IdlevelNavigation { get; set; }
        public virtual School IdschoolNavigation { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TestOfStudent> TestOfStudents { get; set; }
    }
}
