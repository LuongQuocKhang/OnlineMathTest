using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.ViewModel
{
    public class FileViewModel
    {
        public string FileName { get; set; }
        public string DisplayName { get; set; }
        public string FilePath { get; set; }
        public double FileSize { get; set; }
        public byte[] Data { get; set; }
        public string Extension { get; set; }
        public int FileType { get; set; }
        public string ContentType { get; set; }
        public string Source { get; set; }
        public DateTime CreatedOn { get; set; }
        public string BlobName { get; set; }
        public int CreatedBy { get; set; }
    }
}
