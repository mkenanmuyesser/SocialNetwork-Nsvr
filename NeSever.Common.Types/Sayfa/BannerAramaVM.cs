using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class BannerAramaVM
    {
        public int? BannerId { get; set; }
        public int? BannerTipId { get; set; }
        public string Adi { get; set; }
        public string Link { get; set; }

        public byte[] Resim { get; set; }
        public int? Sira { get; set; }
        public int AktifMi { get; set; }
        public IEnumerable<BannerTipVM> BannerTipleri { get; set; }
		public int draw { get; set; }
		public int start { get; set; }
		public int length { get; set; }
	}
}
