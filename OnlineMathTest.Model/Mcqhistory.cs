using System;
using System.Collections.Generic;

namespace OnlineMathTest.Models.Models
{
    public partial class Mcqhistory
    {
        public int Id { get; set; }
        public int Mcqid { get; set; }
        public int QuestionId { get; set; }
        public int UserTestId { get; set; }
        public int QuestionAnswerId { get; set; }
        public DateTime? CreateOn { get; set; }
        public int? CreateBy { get; set; }

        public virtual Mcq Mcq { get; set; }
        public virtual Question Question { get; set; }
        public virtual QuestionAnswer QuestionAnswer { get; set; }
        public virtual UserTest UserTest { get; set; }
    }
}
