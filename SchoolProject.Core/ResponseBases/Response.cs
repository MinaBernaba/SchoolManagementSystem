using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Bases
{
    public class Response<T>
    {
        #region Props
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        //public Dictionary<string, List<string>> ErrorsBag { get; set; }
        public object Meta { get; set; }
        #endregion

        #region ctors 
        public Response()
        {

        }
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }
        #endregion
    }
}
