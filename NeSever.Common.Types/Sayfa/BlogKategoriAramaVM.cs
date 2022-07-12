using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class BlogKategoriAramaVM
    {
        public int?  BlogKategoriId { get; set; }
        public string BlogKategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public int? Sira { get; set; }
        public int AktifMi { get; set; }
        public int draw { get; set; }
		public int start { get; set; }
		public int length { get; set; }
	}
}
