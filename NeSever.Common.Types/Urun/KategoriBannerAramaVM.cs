using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Urun
{
    public class KategoriBannerAramaVM
    {
        public int? KategoriBannerId { get; set; }
        public int? UstKategoriId { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public bool AnasayfadaGoster { get; set; }
        public string Parametre { get; set; }
        public int AktifMi { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
