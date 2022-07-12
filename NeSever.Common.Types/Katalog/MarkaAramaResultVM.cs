using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Katalog
{
    public class MarkaAramaResultVM
    {
		public int TotalCount { get; set; }
		public int MarkaId { get; set; }
		public int WebSiteId { get; set; }
		public string MarkaAdi { get; set; }
		public string WebSiteAdi { get; set; }
		public string Aciklama { get; set; }
		public string ResimUrl { get; set; }
		public byte[] Resim { get; set; }
		public bool AnasayfadaGosterilsin { get; set; }

		public string AnasayfaDurum{ get; set; }
		public string MetaKeywords { get; set; }
		public string MetaDescription { get; set; }
		public string MetaTitle { get; set; }
		public int KayitTarih { get; set; }
		public int Sira { get; set; }
		public bool AktifMi { get; set; }

		public string ResimBase64 { get; set; }
		public string Durum { get; set; }
	}
}
