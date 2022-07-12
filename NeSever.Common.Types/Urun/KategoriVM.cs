using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Urun
{
    public class KategoriVM
    {
        public int KategoriId { get; set; }
        public int? UstKategoriId { get; set; }
        public string  KategoriAdi { get; set; }
        public string Aciklama { get; set; }

        public string AciklamaContent { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public  bool AnasayfadaGoster { get; set; }
        public bool SabitKategori { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }
        public string ResimBase64 { get; set; }
        public string Parametre { get; set; }

        public List<KategoriVM> UstKategoriListesi { get; set; }

        public string KategoriUrunSayisi { get; set; }

    }
}
