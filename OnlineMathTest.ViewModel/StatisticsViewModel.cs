using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.ViewModel
{
    public class StatisticsViewModel
    {
        public List<int> ChartCorrectAnswer { get; set; }
        public List<int> ChartWrongAnswer { get; set; }
        public List<string> Type { get; set; }
    }
}
