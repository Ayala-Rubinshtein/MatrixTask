using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class TestOfStudent
    {
        public TestOfStudent()
        {
            AnswerOfStudents = new HashSet<AnswerOfStudent>();
        }

        public int IdtestToStudent { get; set; }
        public int IdTest { get; set; }
        public int? IdStudent { get; set; }
        public int? Score { get; set; }
        public DateTime? BeginDate { get; set; }
        public TimeSpan? BeginTime { get; set; }
        public DateTime? FinishDate { get; set; }
        public TimeSpan? FinishTime { get; set; }
        public string Folder { get; set; }
        public string VoiceSystem { get; set; }

        public virtual Student IdStudentNavigation { get; set; }
        public virtual Test IdTestNavigation { get; set; }
        public virtual ICollection<AnswerOfStudent> AnswerOfStudents { get; set; }
    }
}
