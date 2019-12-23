using System;
using System.Collections.Generic;

namespace OnlineMathTest.Models.Models
{
    public partial class Mcq
    {
        public Mcq()
        {
            Mcqhistory = new HashSet<Mcqhistory>();
            Mcqquestion = new HashSet<Mcqquestion>();
            UserTest = new HashSet<UserTest>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? NumberOfQuestion { get; set; }
        public int? Duration { get; set; }
        public string Type { get; set; }
        public int? LevelType { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Views { get; set; }
        public int? Attempts { get; set; }
        public string ExamType { get; set; }

        public virtual Level LevelTypeNavigation { get; set; }
        public virtual ICollection<Mcqhistory> Mcqhistory { get; set; }
        public virtual ICollection<Mcqquestion> Mcqquestion { get; set; }
        public virtual ICollection<UserTest> UserTest { get; set; }
    }
}
