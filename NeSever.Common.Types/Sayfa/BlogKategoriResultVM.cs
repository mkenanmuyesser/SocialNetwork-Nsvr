using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class BlogKategoriResultVM
    {
        public int TotalCount { get; set; }
        public int BlogKategoriId { get; set; }
        public string BlogKategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public int Sira { get; set; }
        public string Durum { get; set; }
        public string ResimBase64 { get; set; }
    }
}
