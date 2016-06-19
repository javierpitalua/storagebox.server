using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.DataAccess
{
    public partial class Applications
    {
        /// <summary>
        /// Given an application key, retrieves the instance of the application
        /// </summary>
        /// <param name="applicationKey">The UUID of the application to be retrieved from db</param>
        /// <returns></returns>
        public static Entities.Application LoadApplicationByKey(string applicationKey)
        {
            var query = new DataAccess.ApplicationQueryBuilder();
            query.Where(ApplicationsSchema.Columns.ApplicationKey).IsEqualTo(applicationKey);
            return query.FetchSingle();
        }
    }
}
