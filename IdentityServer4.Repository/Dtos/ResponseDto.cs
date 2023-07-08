using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityServer4.Repository.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public List<string>? Errors { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        public static ResponseDto<T> Success(T data, int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode };
        }

        public static ResponseDto<T> UnSuccessFul(int statusCode,string Error)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Errors = new List<string>() { Error } };
        }
        public static ResponseDto<T> UnSuccessFul(int statusCode,List<string > Errors)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Errors = Errors };
        }

       public struct ResponseStruct<T>
        {
            public static IActionResult Response(ResponseDto<T> response)
            {
                if(response.StatusCode!=204)
                {
                    string JsonSerialize= JsonSerializer.Serialize(response);
                    return new ObjectResult(JsonSerialize); //burada gelen response'u Json'a çevirdik
                }
                return new ObjectResult(null);

            }
        }
        
    }
}
