using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.ViewModel
{
    public class DataTableNetPostViewModel
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<DataTableColumnViewModel> columns { get; set; }
        public DataTableSearchViewModel search { get; set; }
        public List<DataTableOrderViewModel> order { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
    }
    public class DataTableColumnViewModel
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public DataTableSearchViewModel search { get; set; }
    }
    public class DataTableSearchViewModel
    {
        public string value { get; set; }
        public string regex { get; set; }
    }
    public class DataTableOrderViewModel
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
    public class DataTableResultNetViewModel
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public dynamic data { get; set; }
    }
}
