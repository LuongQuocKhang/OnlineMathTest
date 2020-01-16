using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.ViewModel
{
    public class QuestionAnswerViewModel
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public string Choice { get; set; }
        public string AnswerType { get; set; }
        public string AnswerTypeChoice { get; set; }
        public int? DisplayNumber { get; set; }
        public DateTime? CreateOn { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; } = false;

    }
}
