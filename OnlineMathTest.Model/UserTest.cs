using System;
using System.Collections.Generic;

namespace OnlineMathTest.Models.Models
{
    public partial class UserTest
    {
        public UserTest()
        {
            Mcqhistory = new HashSet<Mcqhistory>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int Mcqid { get; set; }
        public double? Point { get; set; }
        public DateTime? CreateOn { get; set; }

        public virtual Mcq Mcq { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Mcqhistory> Mcqhistory { get; set; }
    }
}
