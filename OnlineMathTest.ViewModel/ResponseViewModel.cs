using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.ViewModel
{
    public class ResponseViewModel
    {
        public bool success { get; set; }
        public string errCode { get; set; }
        public string errMsg { get; set; }
        public dynamic data { get; set; }
    }
}
