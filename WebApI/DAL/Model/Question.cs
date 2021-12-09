using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Model
{
    public partial class Question
    {
        public Question()
        {
            AnswerOfStudents = new HashSet<AnswerOfStudent>();
        }

        public int Idquestion { get; set; }
        public int? Idtest { get; set; }
        public int? QuestionNumber { get; set; }
        public int? NumberOfAnswers { get; set; }
        public int? NumberOfCurrectAnswer { get; set; }
        public int? Score { get; set; }

        public virtual Test IdtestNavigation { get; set; }
        public virtual ICollection<AnswerOfStudent> AnswerOfStudents { get; set; }
    }
}
