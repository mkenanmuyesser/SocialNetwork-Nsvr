using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Icerik
{
    public class HobiVM
    {
        public int HobiId { get; set; }
        public string HobiAdi { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }
    }


}
