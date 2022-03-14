using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Dtos
{
    public class CustomResponse<T>
    {
        public CustomResponse()
        {
            ErrorMessages = new List<string>();
        }
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
