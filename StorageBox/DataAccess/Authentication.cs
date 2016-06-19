using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message)
        {

        }
    }
}

namespace StorageBox.DataAccess
{
    public class Authentication
    {
        /// <summary>
        /// Validates the given credentials and returns a session id when succesful authentication
        /// </summary>
        /// <param name="applicationKey"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="deviceDescription"></param>
        /// <returns></returns>
        public static string StartSession(string applicationKey, string userName, string password, string deviceDescription)
        {
            string sessionId = "";
            var application = DataAccess.Applications.LoadApplicationByKey(applicationKey);

            if (application == null)
            {
                throw new AuthenticationException(string.Format("Unable to find application with the given key.  Authentication cannot continue."));
            }

            var account = DataAccess.Accounts.ValidateCredentials(application.Id, userName, password);
            if (account != null)
            {
                sessionId = DataAccess.Sessions.StartSession(account.Id, deviceDescription);
            }
            else
            {
                throw new AuthenticationException("Invalid credentials");
            }

            return sessionId;
        }
    }
}
