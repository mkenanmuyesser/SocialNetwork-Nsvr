using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{

    public partial class HediyeKart : Entity
    {
        public HediyeKart()
        {
            KullaniciHediyeKart = new HashSet<KullaniciHediyeKart>();
        }

        public int HediyeKartId { get; set; }
        public string HediyeKartAdi { get; set; }
        public string Aciklama { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public string KucukResimUrl { get; set; }
        public byte[] KucukResim { get; set; }
        public DateTime KayitTarih { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }
        public int HediyeKartKategoriId { get; set; }

        public virtual ICollection<KullaniciHediyeKart> KullaniciHediyeKart { get; set; }
        public virtual HediyeKartKategori HediyeKartKategori { get; set; }
    }
}
