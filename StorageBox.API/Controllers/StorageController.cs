using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StorageBox.API.Models
{
    /// <summary>
    /// Call object to retrieve file action
    /// </summary>
    public class RetrieveFileRequest
    {
        /// <summary>
        /// The id of the file to be retrieved
        /// </summary>
        public string FileId { get; set; }
    }

    /// <summary>
    /// Contains file information when file is retrieved
    /// </summary>
    public class RetrieveFileResponse : Models.ServiceResponse
    {
        /// <summary>
        /// The id of the file
        /// </summary>
        public string FileID { get; set; }

        /// <summary>
        /// The original name of the file
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The encoded array of bytes of the file as BASE64
        /// </summary>
        public string FileContent { get; set; }

        /// <summary>
        /// The suggested mime type (as in the service database).
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Sets or gets the extension of the instance
        /// </summary>
        public string Extension { get; set; }
    }

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

        /// <summary>
        /// Given a valid FileID, retrieves the content of the file.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("RetrieveFile"), HttpPost]
        public Models.RetrieveFileResponse RetrieveFile(Models.RetrieveFileRequest model)
        {
            var response = new Models.RetrieveFileResponse();

            try
            {
                var file = DataAccess.Files.RetrieveFile(this.CurrentSession, model.FileId);
                response.FileID = model.FileId;
                response.FileName = file.FileName;
                response.FileContent = file.FileContent;
                response.MimeType = file.MimeType;
                response.Extension = file.Extension;
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