using System;
using System.Collections.Generic;

namespace OnlineMathTest.Models.Models
{
    public partial class QuestionAnswer
    {
        public QuestionAnswer()
        {
            Mcqhistory = new HashSet<Mcqhistory>();
        }

        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public string Choice { get; set; }
        public string AnswerType { get; set; }
        public string AnswerTypeChoice { get; set; }
        public int? DisplayNumber { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<Mcqhistory> Mcqhistory { get; set; }
    }
}
