using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class DataHataLog : Entity
    {
        public int ErrorLogId { get; set; }
        public int WebSiteId { get; set; }
        public string ProcessName { get; set; }
        public string ErrorLogContent { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public virtual WebSite WebSite { get; set; }
    }
}
