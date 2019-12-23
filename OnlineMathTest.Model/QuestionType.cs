using System;
using System.Collections.Generic;

namespace OnlineMathTest.Models.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string QuestionType1 { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Question> Question { get; set; }
    }
}
