using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models
{
    public class ServiceResponse
    {
        public object Result { get; set; }
        public string Code { get; set; }
        public bool HasError { get; set; }
        public string Status {get; set;}
    }
}
