using System;
using System.Collections.Generic;

namespace OnlineMathTest.Models.Models
{
    public partial class Mcqquestion
    {
        public int Id { get; set; }
        public int McqquestionId { get; set; }
        public int QuestionId { get; set; }

        public virtual Mcq McqquestionNavigation { get; set; }
        public virtual Question Question { get; set; }
    }
}
