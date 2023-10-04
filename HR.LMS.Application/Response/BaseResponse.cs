using HR.LMS.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LMS.Application.Response
{
    public class BaseResponse
    {
        public int Id {  get; set; }
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; } = String.Empty;
        public Code Code { get; set; } = Code.FAILURE;
        public List<string>? Errors { get; set; }
    }
}
