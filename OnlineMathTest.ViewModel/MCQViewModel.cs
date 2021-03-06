﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.ViewModel
{
    public class MCQViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? NumberOfQuestion { get; set; }
        public int? Duration { get; set; }
        public string Type { get; set; }
        public int? LevelType { get; set; }
        public DateTime? CreateOn { get; set; } = DateTime.Now;
        public bool? IsDeleted { get; set; } = false;
        public int? Views { get; set; }
        public int? Attempts { get; set; }
        public string ExamType { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
    }
}
