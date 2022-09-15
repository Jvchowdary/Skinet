using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode,string message=null)
        {
            StatusCode=statusCode;
            Message=message??GetDefaultMessage(statusCode);
        }


        public int StatusCode { get; set; }
        public string Message { get; set; }

        
        private string GetDefaultMessage(int statusCode)
        {
             return statusCode switch
             {
                400=>"A bad Request",
                401=>"Authorized,you are not",
                404=>"Resource Found,it was not",
                500=>"Errors are path",
                _=>null
             };
        }

    }
}