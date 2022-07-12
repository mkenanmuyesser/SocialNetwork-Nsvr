using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciHediyeKartKayitVM
    {
        public int KullaniciHediyeKartId { get; set; }
        public Guid GonderenKullaniciId { get; set; }
		public Guid AliciKullaniciId { get; set; }
        public int HediyeKartId { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool OkunduMu { get; set; }
        public bool GonderenAktifMi { get; set; }

        public bool AlanAktifMi { get; set; }

        public bool AktifMi { get; set; }


	}
}
