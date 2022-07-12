using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Urun
{
    public class UrunResimVM
    {
        public int UrunResimId { get; set; }
        public int UrunId { get; set; }
        public string OrjinalResimUrl { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public int Sira { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool AktifMi { get; set; }
        public string ResimBase64 { get; set; }

    }
}
