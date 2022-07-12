using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class BlogAramaResultVM
    {
        public int TotalCount { get; set; }
        public int BlogId { get; set; }
        public string KisaIcerik { get; set; }
        public string  Kategori { get; set; }
        public string Baslik { get; set; }
        public string Etiketler { get; set; }
        public string OkunmaSayisi { get; set; }
        public string YayinTarihi { get; set; }
        public string  Durum { get; set; }
        public string ResimBase64 { get; set; } 
    }
}
