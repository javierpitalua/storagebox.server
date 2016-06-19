using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.DataAccess
{
    public partial class Sessions
    {

        public static Entities.Session LoadSessionByUUID(string sessionUUID)
        {
            var query = new DataAccess.SessionQueryBuilder();
            query.Where(SessionsSchema.Columns.SessionUUID).IsEqualTo(sessionUUID);
            return query.FetchSingle();
        }

        /// <summary>
        /// Starts and logs an account session
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="deviceDescription"></param>
        /// <returns></returns>
        public static string StartSession(int accountId, string deviceDescription)
        {
            var session = new Entities.Session()
            {
                Account_Id = accountId,
                SessionUUID = Guid.NewGuid().ToString().ToUpper(),
                StartedOn = DateTime.UtcNow,
                Enabled = true,
                Device = deviceDescription
            };

            DataAccess.Sessions.Create(session);
            return session.SessionUUID;
        }


        /// <summary>
        /// Validates if session exists and is enabled
        /// </summary>
        /// <param name="sessionID"></param>
        /// <returns>If session is valid, returns the instance of the session.</returns>
        public static Entities.Session ValidateSession(string sessionID)
        {
            var session = LoadSessionByUUID(sessionID);

            if (session == null)
            {
                throw new Exceptions.AccessDeniedException("Session ID is invalid or has expired.");
            }

            if (session.Enabled != true)
            {
                throw new Exceptions.AccessDeniedException("Session has expired.  Please start a new session.");
            }

            return session;
        }
    }
}
