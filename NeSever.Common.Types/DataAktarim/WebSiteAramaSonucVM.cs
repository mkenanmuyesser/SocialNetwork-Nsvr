using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{

    public class WebSiteAramaSonucVM
    {
        public int WebSiteId { get; set; }
        public string WebSiteAdi { get; set; }
        public string WebSiteUrl { get; set; }
        public string ResimYolu { get; set; }
        public byte[] Resim { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime GuncellemeTarih { get; set; }
        public bool AktifMi { get; set; }
        public string ResimBase64{ get; set; }

        public string Durum { get; set; }
        public int TotalCount { get; set; }



    }
}
