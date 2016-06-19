using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.DataAccess
{
    public class Files
    {
        public static string PersistFile(Entities.Session session, string originalFileName, string fileContent)
        {
            var persister = new FilePersister(Properties.Settings.Default.StorageLocation);
            return persister.PersistFile(session, originalFileName, fileContent);
        }

        public static Entities.FileContent RetrieveFile(string fileId)
        {
            return new Entities.FileContent();
        }
    }
}
