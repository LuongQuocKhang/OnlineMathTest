using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.ViewModel
{
    public class MCQQuestionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double? Point { get; set; }
        public int? QuestionType { get; set; }
        public int? LevelType { get; set; }
        public string CorrectAnswer { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }
        public List<QuestionAnswerViewModel> Answers { get; set; }
    }
}
