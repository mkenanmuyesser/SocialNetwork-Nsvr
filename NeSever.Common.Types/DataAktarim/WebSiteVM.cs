using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{
    public class WebSiteVM
    {
        public WebSiteVM()
        {
            WebSiteBilgileri = new WebSiteBilgileriVM();
            AramaFiltreleri = new WebSiteAramaVM();
            WebSiteAramaSonucList = new List<WebSiteAramaSonucVM>();
        }



        public IEnumerable<WebSiteAramaSonucVM> WebSiteAramaSonucList { get; set; }

        public WebSiteAramaVM AramaFiltreleri { get; set; }

        public WebSiteBilgileriVM WebSiteBilgileri { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public int TotalCount { get; set; }


    }
}
