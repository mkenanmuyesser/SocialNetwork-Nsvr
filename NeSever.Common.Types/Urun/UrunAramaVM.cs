using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Urun
{
    public class UrunAramaVM
    {
		public int? UrunId { get; set; }
		public string Sku { get; set; }
		public string UrunAdi { get; set; }
		public string AdresUrl { get; set; }
		public string Aciklama { get; set; }
		public int AktifMi { get; set; }
		public int SatilabilirUrunMu { get; set; }
		public int draw { get; set; }
		public int start { get; set; }
		public int length { get; set; }
		public List<KategoriVM> KategoriListesi { get; set; }
		public string secilenKategoriListesi { get; set; }
	}
}
