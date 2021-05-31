using Newtonsoft.Json;
using System.Collections.Generic;

namespace Webmotors.Infraestructure.ApiModels
{
    public class Error
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; set; }

        
    }

    public class ResponseError
    {
        public List<Error> Errors { get; set; }

        public ResponseError()
        {
            Errors = new List<Error>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
