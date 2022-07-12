using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class DataUrunLink : Entity
    {
        public int ProductLinkHistoryId { get; set; }
        public int WebSiteId { get; set; }
        public string ProductLink { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual WebSite WebSite { get; set; }
    }
}
