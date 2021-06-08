using Newtonsoft.Json;
using System;
using System.Text;

namespace Core.Extensions.Concrete
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ErrorDetails<T>
    {
        public ErrorDetails(T data, string message) : this(false)
        {
            Data = data;
            Message = message;
        }

        public ErrorDetails(T data) : this(false)
        {
            Data = data;
        }
        public ErrorDetails(bool success)
        {
            Success = success;
        }


        public bool Success { get; }

        public string Message { get; }

        public T Data { get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
