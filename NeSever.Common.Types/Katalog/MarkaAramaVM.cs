using NeSever.Common.Models.DataAktarim;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Katalog
{
    public class MarkaAramaVM
    {
        public int? MarkaId { get; set; }

        public int? WebSiteId { get; set; }
        public string MarkaAdi { get; set; }
        public int AktifMi { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }

        public IEnumerable<WebSiteAramaSonucVM> WebSiteListesi { get; set; }
    }
}
