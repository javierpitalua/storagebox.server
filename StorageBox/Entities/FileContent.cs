using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.Entities
{
    public class FileContent
    {
        public string FileName { get; set; }
        public string Content { get; set; }
        public string MimeType { get; set; }
    }
}
