using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.ViewModel
{
    public class McqHistoryViewModel
    {
        public int Id { get; set; }
        public int Mcqid { get; set; }
        public int QuestionId { get; set; }
        public int UserTestId { get; set; }
        public int QuestionAnswerId { get; set; }
        public string Choice { get; set; }
    }
}
