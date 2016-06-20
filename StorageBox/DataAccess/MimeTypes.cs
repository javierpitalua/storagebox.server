using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.DataAccess
{
    public partial class MimeTypes
    {
        /// <summary>
        /// Given an extension, returns the corresponding mime type
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static Entities.MimeType GetMimeTypeByExtension(string extension)
        {
            var query = new DataAccess.MimeTypeQueryBuilder();
            query.Where(MimeTypesSchema.Columns.Extension).IsEqualTo(extension.Trim().ToLower());
            return query.FetchSingle();
        }
    }
}
