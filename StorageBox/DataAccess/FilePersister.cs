using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.DataAccess
{
    public class FilePersistenceException : Exception
    {
        public FilePersistenceException(string errorMessage) : base(errorMessage)
        {

        }
    }

    public class FilePersister
    {
        public string DefaultOutputLocation { get; set; }

        public FilePersister(string defaultOutputLocation)
        {
            this.DefaultOutputLocation = DefaultOutputLocation;
        }

        private string GetDestinationDirectory(string applicationID)
        {
            return System.IO.Path.Combine(applicationID, string.Format(@"{0:00}{1}", DateTime.Now.Month, DateTime.Now.Year));
        }

        public string PersistFile(Entities.Session session, string fileName, string fileContent)
        {
            var fileId = Guid.NewGuid().ToString().ToUpper();
            var account = session.Account;
            var application = account.Application;

            var finalDestination = GetDestinationDirectory(application.ApplicationKey);
            var outputDir = System.IO.Path.Combine(
                Properties.Settings.Default.StorageLocation, finalDestination);

            if (!System.IO.Directory.Exists(outputDir))
            {
                System.IO.Directory.CreateDirectory(outputDir);
            }

            var extension = System.IO.Path.GetExtension(fileName);
            var localFile = string.Format("{0}{1}", fileId, extension);
            var outputFileName = System.IO.Path.Combine(outputDir, localFile);

            var bytes = System.Convert.FromBase64String(fileContent);

            System.IO.File.WriteAllBytes(outputFileName, bytes);

            var storageFile = new Entities.StorageFile()
            {
                FileUUID = fileId,
                FileName = fileName,
                UploadedOn = DateTime.UtcNow,
                Extension = extension,
                StoragePath = finalDestination,
                FileSize = bytes.Length,
                Session_Id = session.Id
            };

            DataAccess.StorageFiles.Create(storageFile);

            return fileId;
        }
    }
}
