using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.DataAccess
{
    public partial class Accounts
    {
        /// <summary>
        /// Determines if credentials are valid.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Entities.Account ValidateCredentials(int applicationId, string userName, string password)
        {
            Entities.Account returnValue = null;
            var query = new DataAccess.AccountQueryBuilder();
            query.Where(AccountsSchema.Columns.Application_Id).IsEqualTo(applicationId);
            query.Where(AccountsSchema.Columns.Name).IsEqualTo(userName);

            var found = query.FetchSingle();

            if (found != null)
            {
                if(found.Password.Trim() == password.Trim())
                {
                    found.LastAuthenticationOn = DateTime.UtcNow;
                    DataAccess.Accounts.Save(found);
                    returnValue = found;
                }
            }

            return returnValue;
        }
    }
}
