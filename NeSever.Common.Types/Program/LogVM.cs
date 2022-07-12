using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Program
{
    public class LogVM
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string MessageTemplate { get; set; }
        public int LevelId { get; set; }
        public string Level { get; set; }
        public string TimeStamp { get; set; }
        public string  Exception { get; set; }
        public string Properties { get; set; }
        public int TotalCount { get; set; }
    }
}
