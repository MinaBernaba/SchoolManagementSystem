using System.Net;

namespace SchoolProject.Core.Bases
{
    public class ResponseHandler
    {
        public ResponseHandler() { }
        public Response<T> Success<T>(T entity, object meta = null, string message = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message == null ? "Bad Request" : message,
                Meta = meta
            };
        }
        public Response<T> Created<T>(object meta = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                Meta = meta
            };
        }
        public Response<T> Updated<T>(object meta = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Updated",
                Meta = meta
            };
        }
        public Response<T> Deleted<T>(object meta)
        {
            return new Response<T>()
            {
                Meta = meta,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }
        public Response<T> UnAuthorized<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = message == null ? "Bad Request" : message
            };
        }
        public Response<T> BadRequest<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message == null ? "Bad Request" : message
            };
        }
        public Response<T> UnprocessableEntity<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message == null ? "Unprocessabl eEntity" : message
            };
        }
        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }
    }
}