using System;
using System.Collections.Generic;

namespace OnlineMathTest.Models.Models
{
    public partial class Question
    {
        public Question()
        {
            Mcqhistory = new HashSet<Mcqhistory>();
            Mcqquestion = new HashSet<Mcqquestion>();
            QuestionAnswer = new HashSet<QuestionAnswer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public double? Point { get; set; }
        public int? QuestionType { get; set; }
        public int? LevelType { get; set; }
        public string CorrectAnswer { get; set; }
        public string ImageLink { get; set; }
        public string Guide { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Level LevelTypeNavigation { get; set; }
        public virtual QuestionType QuestionTypeNavigation { get; set; }
        public virtual ICollection<Mcqhistory> Mcqhistory { get; set; }
        public virtual ICollection<Mcqquestion> Mcqquestion { get; set; }
        public virtual ICollection<QuestionAnswer> QuestionAnswer { get; set; }
    }
}
