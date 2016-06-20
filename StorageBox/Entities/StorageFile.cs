using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.Entities
{
    public partial class StorageFile
    {
        /// <summary>
        /// Gets the mime type given an extension
        /// </summary>
        /// <returns></returns>
        public string GetMimeType()
        {
            var mime = DataAccess.MimeTypes.GetMimeTypeByExtension(this.Extension);
            return mime != null ? mime.MediaType : "application/octet-stream";
        }

        /// <summary>
        /// Reads the phisically stored file an returns the content as a base64 string.
        /// </summary>
        /// <returns></returns>
        public string LoadFileContentAsBASE64()
        {
            var storedFile = System.IO.Path.Combine(
                    Properties.Settings.Default.StorageLocation,
                    this.StoragePath,
                    string.Format("{0}{1}", this.FileUUID, this.Extension));
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(storedFile));
        }
    }
}
