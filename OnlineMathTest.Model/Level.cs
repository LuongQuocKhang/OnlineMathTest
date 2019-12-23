using System;
using System.Collections.Generic;

namespace OnlineMathTest.Models.Models
{
    public partial class Level
    {
        public Level()
        {
            Mcq = new HashSet<Mcq>();
            Question = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string LevelName { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Mcq> Mcq { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
