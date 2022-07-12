using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{
    public class HataLogAramaSonucVM
    {
        public int ErrorLogId { get; set; }
        public string  WebSiteAdi { get; set; }
        public string ProcessName { get; set; }
        public string ErrorLogContent { get; set; }
        public string LastModifiedDate { get; set; }

        public int TotalCount { get; set; }
    }
}
