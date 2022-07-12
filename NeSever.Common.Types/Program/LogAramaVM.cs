using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Program
{
    public class LogAramaVM
    {
    
        public int? Id { get; set; }
        public int? LevelId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }

    }
}
