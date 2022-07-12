using System;
using System.Collections.Generic;
using System.Text;
using NeSever.Common.Models.DataAktarim;
using NeSever.Common.Models.Katalog;

namespace NeSever.Common.Models.Urun
{
    public class UrunVM

    {
        public int UrunId { get; set; }
        public string OriginalId { get; set; }
		public int MarkaId { get; set; }
		public string Sku { get; set; }
		public string UrunAdi { get; set; }
		public string KisaAciklama { get; set; }
		public string Aciklama { get; set; }
		public string KisaAciklamaContent { get; set; }
		public string AciklamaContent { get; set; }
		public string Etiketler { get; set; }
		public string AdresUrl { get; set; }
		public bool AnasayfadaGoster { get; set; }
		public int GoruntulenmeSayisi { get; set; }
		public string MetaKeywords { get; set; }
		public string MetaDescription { get; set; }
		public string MetaTitle { get; set; }
		public DateTime KayitTarih { get; set; }
		public DateTime GuncellemeTarih { get; set; }
		public int? Sira { get; set; }
		public bool AktifMi { get; set; }
		public decimal Fiyat { get; set; }
		public bool SatilabilirUrun { get; set; }
		public int? WebSiteId { get; set; }
		public byte[] Resim { get; set; }
		public List<MarkaVM> MarkaListesi { get; set; }

		public List<KategoriVM> KategoriListesi { get; set; }
		public string SecilenKategoriListesi { get; set; }
		public List<UrunResimVM> UrunResimListesi { get; set; }

		public List<UrunKategoriVM> UrunKategoriListesi { get; set; }

		public string SecilenKategoriler { get; set; }
		public List<WebSiteAramaSonucVM> WebSiteListesi { get; set; }
	}
}
