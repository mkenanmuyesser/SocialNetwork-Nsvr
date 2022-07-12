using NeSever.Common.Models.Icerik;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class HediyeKartDetaySonucVM
    {
        public int HediyeKartId { get; set; }
        public KullaniciVM GonderenKullanici { get; set; }
        public KullaniciVM AliciKullanici { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Aciklama { get; set; }
        public HediyeKartVM HediyeKart { get; set; }
    }
}
