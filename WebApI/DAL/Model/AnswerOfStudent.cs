using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class AnswerOfStudent
    {
        public int IdanswerOfStudent { get; set; }
        public int? IdtestOfStudent { get; set; }
        public int? Idquestion { get; set; }
        public int? SelectedAnswer { get; set; }
        public int? Score { get; set; }
        public DateTime? BeginDate { get; set; }
        public TimeSpan? BeginTime { get; set; }
        public DateTime? FinishDate { get; set; }
        public TimeSpan? FinishTime { get; set; }

        public virtual Question IdquestionNavigation { get; set; }
        public virtual TestOfStudent IdtestOfStudentNavigation { get; set; }
    }
}
