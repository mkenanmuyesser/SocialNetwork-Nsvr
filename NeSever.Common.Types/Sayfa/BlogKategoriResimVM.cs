using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class BlogKategoriResimVM
    {
        public int BlogKategoriResimId { get; set; }
        public int BlogKategoriId { get; set; }
		public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
		public string Aciklama { get; set; }
		public string AltAttribute { get; set; }
		public string TitleAttribute { get; set; }
		public bool AktifMi { get; set; }
		public string ResimBase64 { get; set; }
	}
}
