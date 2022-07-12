using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{
   public  class UrunLinkIslemAramaSonucVM
    {
        public int Id { get; set; }

        public string  WebSitesi { get; set; }
        public string UrunLinki { get; set; }
        public string IslemTarihi { get; set; }
        public string Durum { get; set; }

        public int TotalCount { get; set; }

    }
}
