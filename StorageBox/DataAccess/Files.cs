using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.DataAccess
{
    public class FileRecord
    {
        public string FileName { get; set; }
        public string FileContent { get; set; }
        public string MimeType { get; set; }
    }

    public class Files
    {
        public static string PersistFile(Entities.Session session, string originalFileName, string fileContent)
        {
            var persister = new FilePersister(Properties.Settings.Default.StorageLocation);
            return persister.PersistFile(session, originalFileName, fileContent);
        }

        public static FileRecord RetrieveFile(Entities.Session session, string fileId)
        {
            var storageFile = DataAccess.StorageFiles.LoadByUUID(fileId);
            FileRecord fileRecord = null;

            if (storageFile != null)
            {
                //Does file belongs to the same application:
                if (storageFile.Session?.Account?.Application_Id == session.Account?.Application_Id)
                {
                    fileRecord = new FileRecord()
                    {
                        FileName = System.IO.Path.GetFileName(storageFile.FileName),
                        FileContent = storageFile.LoadFileContentAsBASE64(),
                        MimeType = storageFile.GetMimeType()
                    };
                }
                else
                {
                    throw new Exception("File access restricted.");
                }
            }
            else
            {
                throw new Exception("File not found.");
            }

            return fileRecord;
        }
    }
}
