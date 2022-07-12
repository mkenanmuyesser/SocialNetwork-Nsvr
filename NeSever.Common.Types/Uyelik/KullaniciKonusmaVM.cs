using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciKonusmaVM
    {
        public int KullaniciKonusmaId { get; set; }
        public Guid GonderenKullaniciId { get; set; }
        public Guid AliciKullaniciId { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool AktifMi { get; set; }

        public bool GonderenKullaniciAktifMi { get; set; }
        public bool AliciKullaniciAktifMi { get; set; }
        public KullaniciVM GonderenKullanici { get; set; }
        public KullaniciVM AliciKullanici { get; set; }
    }
}
