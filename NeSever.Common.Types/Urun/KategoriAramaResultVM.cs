using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Urun
{
    public class KategoriAramaResultVM
    {
        public int TotalCount { get; set; }
        public int KategoriId { get; set; }
        public int? UstKategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string UstKategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public bool AnasayfadaGoster { get; set; }
        public string AnasayfadaGosterDurum { get; set; }
        public string ResimUrl { get; set; }
        public bool SabitKategori { get; set; }
        public string SabitKategoriDurum { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public int Sira { get; set; }
        public string Durum { get; set; }
        public string ResimBase64 { get; set; }
    }
}
