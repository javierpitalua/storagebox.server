using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace StorageBox.API.Models
{
    /// <summary>
    /// This model must be specified when authentication is requested
    /// </summary>
    public class AuthenticationModel : ServiceRequestBaseModel
    {
        /// <summary>
        /// All authentication requests must be related to an application via this key
        /// </summary>
        public string ApplicationKey { get; set; }

        /// <summary>
        /// The user name of the account to be authenticated
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// This is... well, you figure it out ;)
        /// </summary>
        public string Password { get; set; }

        /// <summary>        
        /// Although not required, it helps to identify from where the session was started.
        /// </summary>
        public string DeviceDescription { get; set; }
    }

    /// <summary>
    /// If authentication method is called, an instance of this response is returned
    /// </summary>
    public class AuthenticationResponse : ServiceResponse
    {
        /// <summary>
        /// If authentication is succesful, a session ID will be generated and returned.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// This will set to true when credentials are valid
        /// </summary>
        public bool AuthenticationSuccesful { get; set; }
    }

    /// <summary>
    /// The basic API response, all responses must implement this class
    /// </summary>
    public abstract class ServiceResponse
    {
        /// <summary>
        /// Wheter if service operation completed succesfully
        /// </summary>
        public bool OperationSuccesful { get; set; }

        /// <summary>
        /// If something went wrong on service endpoint a message will be returned.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// If an unhandled exception was raised, 
        /// this property will display as much information as possible on what went wrong on the server.
        /// </summary>
        public string ExceptionDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ServiceResponse()
        {
            this.OperationSuccesful = false;
        }
    }

    /// <summary>
    /// All models should be implemented from this class
    /// </summary>
    public abstract class ServiceRequestBaseModel
    {

    }
}

namespace StorageBox.API.Controllers
{

    /// <summary>
    /// This class holds authentication methods
    /// </summary>
    [RoutePrefix("api/Authentication")]
    public class AuthenticationController : ApiController
    {        
        /// <summary>
        /// Receives and validates account credentials.  When succesful, returns a valid session ID.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Returns a session id if authentication is succesful</returns>
        [Route("StartSession"), HttpPost]
        public Models.AuthenticationResponse StartSession(Models.AuthenticationModel model)
        {
            var response = new Models.AuthenticationResponse();

            try
            {
                response.SessionId = DataAccess.Authentication.StartSession(model.ApplicationKey, model.UserName, model.Password, model.DeviceDescription);
                response.AuthenticationSuccesful = true;
                response.OperationSuccesful = true;
            }            
            catch (Exception ex)
            {
                response.OperationSuccesful = false;
                response.ErrorMessage = ex.Message;
                response.ExceptionDetails = ex.ToString();
            }

            return response;
        }
    }
}