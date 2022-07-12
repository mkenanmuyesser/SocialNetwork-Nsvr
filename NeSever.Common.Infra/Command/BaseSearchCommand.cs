using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Infra.Command
{
    public abstract class BaseSearchCommand
    {
        public int PageSize { get; set; }
        public int Skip { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDir { get; set; }
    }
}
