using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class AnswerOfStudent
    {
        public int Code { get; set; }
        public string IdOfTest { get; set; }
        public string IdOfStudent { get; set; }
        public string IdOfQuestion { get; set; }
        public int StudentAnswer { get; set; }
    }
}
