using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{
    public class HataLogVM
    {
        public int? ErrorLogId { get; set; }
        public int? WebSiteId { get; set; }
        public string  WebSiteAdi { get; set; }
        public string ProcessName { get; set; }
        public string ErrorLogContent { get; set; }
        public string LastModifiedDate { get; set; }

        public string BaslangicTarihi { get; set; }
        public string BitisTarihi { get; set; }
        public List<WebSiteAramaSonucVM> WebSiteListesi { get; set; }

        public List<HataLogAramaSonucVM> HataLogSonucListesi { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }

    }
}
