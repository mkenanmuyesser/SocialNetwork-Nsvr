using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{
    public class WebSiteAramaVM
    {
        public int?  Id { get; set; }
        public string  WebSiteAdi { get; set; }
        public string SiteUrl { get; set; }
        public int AktifMi { get; set; }
    }
}
