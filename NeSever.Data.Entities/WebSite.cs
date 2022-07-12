using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class WebSite : Entity
    {
        public WebSite()
        {
            DataHataLog = new HashSet<DataHataLog>();
            DataUrunLink = new HashSet<DataUrunLink>();
            Marka = new HashSet<Marka>();
            DataKategori = new HashSet<DataKategori>();
        }

        public int WebSiteId { get; set; }
        public string WebSiteAdi { get; set; }
        public string SiteUrl { get; set; }
        public string ResimYolu { get; set; }
        public byte[] Resim { get; set; }
        public DateTime KayitTarih { get; set; }
        public DateTime? GuncellemeTarih { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<DataHataLog> DataHataLog { get; set; }
        public virtual ICollection<DataUrunLink> DataUrunLink { get; set; }
        public virtual ICollection<Marka> Marka { get; set; }
        public virtual ICollection<DataKategori> DataKategori { get; set; }
    }
}
