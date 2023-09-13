using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class HttpResponseResult<T>
    {
        public HttpResponseResult()
        {
            Code = (int)HttpStatusCode.OK;
            Success = true;
            Message = string.Empty;
            Data = Activator.CreateInstance<T>();
            Errors = new List<string>();
        }
        public HttpResponseResult(T data)
        {
            Success = true;
            Message = string.Empty;
            Data = data;
            Errors = new List<string>();
        }

        public HttpResponseResult(T data, string message)
        {
            Success = true;
            Message = message;
            Data = data;
            Errors = new List<string>();
        }

        [JsonPropertyOrder(1)]
        public bool Success { get; set; }

        [JsonPropertyOrder(2)]
        public int Code { get; set; }

        [JsonPropertyOrder(4)]
        public string Message { get; set; }

        [JsonPropertyOrder(5)]
        public List<string> Errors { get; set; }

        [JsonPropertyOrder(3)]
        public T Data { get; set; }
    }
    public class HttpResponseResult
    {
        public HttpResponseResult()
        {
            Success = true;
            Message = string.Empty;
            Errors = new List<string>();
        }
        public HttpResponseResult(string _message)
        {
            Success = true;
            Message = _message;
            Errors = new List<string>();
        }

        [JsonPropertyOrder(1)]
        public bool Success { get; set; }

        [JsonPropertyOrder(2)]
        public int Code { get; set; }

        [JsonPropertyOrder(3)]
        public string Message { get; set; }

        [JsonPropertyOrder(4)]
        public List<string> Errors { get; set; }
    }
}
