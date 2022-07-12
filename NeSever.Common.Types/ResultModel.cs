using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models
{
    public enum ResultType
    {
        Belirsiz,
        Basarili,
        Basarisiz
    }

    public class ResultModel : ResultModel<bool>
    {

    }

    public class ResultModel<T>
    {
        public ResultType Type { get; set; }

        public T Data { get; set; }

        public string ErrorMessage { get; set; }
    }
}
