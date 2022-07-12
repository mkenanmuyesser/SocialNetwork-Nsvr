using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class DuvarResimVM
    {
        public int DuvarResimId { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public string ResimBase64 { get; set; }

        public string ResimUzanti { get; set; }
    }
}
