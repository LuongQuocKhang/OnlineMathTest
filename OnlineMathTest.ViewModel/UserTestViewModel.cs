using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.ViewModel
{
    public class UserTestViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserName { get; set; }
        public int Mcqid { get; set; }
        public string McqTitle { get; set; }
        public double? Point { get; set; }
        public DateTime? CreateOn { get; set; }
    }
}
