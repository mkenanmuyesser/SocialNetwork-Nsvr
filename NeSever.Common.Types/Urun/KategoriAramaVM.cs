using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Urun
{
    public class KategoriAramaVM
    {
        public int? KategoriId { get; set; }
        public int? UstKategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public bool AnasayfadaGoster { get; set; }
        public bool? SabitKategori { get; set; }
        public int SabitKategoriMi { get; set; }
        public int AktifMi { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
