using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMCTravelTour.Service.BaseEntities
{
    public class ResponseResult<T> 
    {
        public ResponseResult()
        {
            IsSuccess = true;
        }
        public ResponseResult(string message)
        {
            IsSuccess = false;
            ErrorMessage = message;
        }
        public ResponseResult(T data)
        {
            IsSuccess = true;
            Data = data;
        }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
