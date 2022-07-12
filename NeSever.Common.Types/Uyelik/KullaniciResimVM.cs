using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace NeSever.Common.Models.Uyelik
{
   public class KullaniciResimVM
    {
        public int KullaniciResim { get; set; }
        public Guid KullaniciId { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public string ResimYorum { get; set; }
        public bool ProfilFotografiMi { get; set; }
        public bool BuyukProfilFotografiMi { get; set; }
        public bool AktifMi { get; set; }
        public int KullaniciResimId { get; set; }

        public DateTime EklenmeTarihi { get; set; }
        public string ResimUzanti { get; set; }
        public string ResimBase64 { get; set; }

        public int? DuvarResimId { get; set; }

        public IPagedList<KullaniciResimVM> KullaniciResimList { get; set; }
    }
}
