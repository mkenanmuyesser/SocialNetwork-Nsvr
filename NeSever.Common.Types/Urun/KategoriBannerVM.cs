using NeSever.Common.Models.Urun;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Urun
{
    public class KategoriBannerVM
    {
        public int KategoriBannerId { get; set; }
        public int? UstKategoriId { get; set; }
        public int? UstKategoriBannerId { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }

        public string AciklamaContent { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public bool AnasayfadaGoster { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }
        public string ResimBase64 { get; set; }
        public string Parametre { get; set; }

        public List<KategoriVM> UstKategoriListesi { get; set; }
        public List<KategoriBannerVM> UstKategoriBannerListesi { get; set; }
    }
}
