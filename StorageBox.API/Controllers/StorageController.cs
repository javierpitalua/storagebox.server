using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StorageBox.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UploadFileModel : Models.ServiceRequestBaseModel
    {
        /// <summary>
        /// The full path name of the original file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// File content must be provided in this property as a byte array encoded as BASE64
        /// </summary>
        public string FileContent { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UploadServiceResponse : Models.ServiceResponse
    {
        /// <summary>
        /// If file was succesfully persisted, file can be retrieved using this ID
        /// </summary>
        public string FileID { get; set; }
    }
}

namespace StorageBox.API.Controllers
{
    /// <summary>
    /// This class holds authentication methods
    /// </summary>
    [RoutePrefix("api/Storage")]
    public class StorageController : AuthenticatedBaseController
    {
        /// <summary>
        /// By calling this action, it is possible to store a file in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("SubmitFile"), HttpPost]
        public Models.UploadServiceResponse SubmitFile(Models.UploadFileModel model)
        {
            var response = new Models.UploadServiceResponse();

            try
            {
                var storageFileId = DataAccess.Files.PersistFile(this.CurrentSession, model.FileName, model.FileContent);
                response.FileID = storageFileId;
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