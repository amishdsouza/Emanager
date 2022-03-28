using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Service.Dtos
{
    public class CustomResponse<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }

    public class PaginationDetails<T>
    {
        public T Items { get; set; }
        public int TotalCount { get; set; }
    }
}
