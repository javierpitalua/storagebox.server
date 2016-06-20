using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.DataAccess
{
    public partial class StorageFiles
    {
        /// <summary>
        /// Gets an instance of a StorageFile from db if exists
        /// </summary>
        /// <param name="uuid"></param>
        /// <returns></returns>
        public static Entities.StorageFile LoadByUUID(string uuid)
        {
            var query = new DataAccess.StorageFileQueryBuilder();
            query.Where(StorageFilesSchema.Columns.FileUUID).IsEqualTo(uuid);
            return query.FetchSingle();
        }
    }
}
