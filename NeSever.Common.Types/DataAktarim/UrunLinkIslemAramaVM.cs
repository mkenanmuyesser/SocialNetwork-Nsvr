using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{
    public class UrunLinkIslemAramaVM
    {
        public int? Id { get; set; }
        public int?  WebSiteId { get; set; }
        public string  UrunLink { get; set; }
        public int AktifMi { get; set; }

        public List<WebSiteAramaSonucVM> WebSiteListesi { get; set; }
    }
}
