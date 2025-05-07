using System.Net;

namespace E_commerce.Application.Hepler
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public Response()
        {
            Errors = new List<string>();
        }

        public Response(T data)
        {
            Succeeded = true;
            Data = data;
            Errors = new List<string>();
        }

        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Errors = new List<string>();
        }
        
    }
}
