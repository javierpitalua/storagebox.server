using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace StorageBox.API.Controllers
{
    /// <summary>
    /// All requests that require authentication must implement this class
    /// </summary>    
    [ProtectBySession]
    public abstract class AuthenticatedBaseController : ApiController
    {
        /// <summary>
        /// If device is authenticated
        /// </summary>
        public Entities.Session CurrentSession { get; set; }
    }
}