using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.Interfaces
{
    public interface IUploadFileService
    {
        bool UploadFileToServerBase64(string imageUrl, string path, string src);
    }
}
