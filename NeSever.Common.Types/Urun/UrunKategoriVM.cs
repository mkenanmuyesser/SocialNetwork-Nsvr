using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Urun
{
    public class UrunKategoriVM
    {
        public int UrunKategoriId { get; set; }
        public int UrunId { get; set; }
        public int KategoriId { get; set; }
        public int Sira { get; set; }
        public string KategoriAdi { get; set; }
        public bool AktifMi { get; set; }

    }
}
