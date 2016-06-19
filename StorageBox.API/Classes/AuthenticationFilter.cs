using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;


namespace StorageBox.API
{
    /// <summary>
    /// All protected request must implement this filter
    /// </summary>    
    public class ProtectBySessionAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// By implementing this action all requests to the action/controller must require _sessionID in the header request.
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ControllerContext.Controller is Controllers.AuthenticatedBaseController)
            {
                try
                {
                    string sessionId = actionContext.Request.Headers.GetValues("_sessionID").FirstOrDefault();
                    if (string.IsNullOrEmpty(sessionId))
                    {
                        throw new HttpResponseException(new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized));
                    }
                    else
                    {
                        var currentSession = DataAccess.Sessions.ValidateSession(sessionId);
                        ((Controllers.AuthenticatedBaseController)actionContext.ControllerContext.Controller).CurrentSession = currentSession;
                    }
                }
                catch (Exceptions.AccessDeniedException accEx)
                {
                    throw new HttpResponseException(new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            base.OnActionExecuting(actionContext);
        }
        //{
        //    /// <summary>
        //    /// Overriding implementation...
        //    /// </summary>
        //    /// <param name="filterContext"></param>
        //    public override void OnActionExecuting(ActionExecutingContext filterContext)
        //    {
        //        if (filterContext.Controller is Controllers.AuthenticatedBaseController)
        //        {
        //            try
        //            {
        //              //  var thisController = filterContext.Controller as Controllers.AuthenticatedBaseController;
        //                
        //                //var session = DataAccess.Sessions.ValidateSession(sessionId);
        //                //((Controllers.AuthenticatedBaseController)).CurrentSession = session;
        //            }
        //            catch (Exception)
        //            {

        //                throw;
        //            }

        //        }

        //        base.OnActionExecuting(filterContext);
        //    }
    }
}