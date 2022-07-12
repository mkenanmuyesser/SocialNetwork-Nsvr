using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{

	public class BlogKayitVM
    {
        public int BlogId { get; set; }
        public int BlogKategoriId { get; set; }
		[StringLength(50)]
		public string Baslik { get; set; }
		[StringLength(500)]
		public string KisaIcerik { get; set; }
		public string Icerik { get; set; }
		[StringLength(500)]
		public string Etiketler { get; set; }
		public string YayinTarihi { get; set; }
        public string BaslangicTarihi { get; set; }
		public string BitisTarihi { get; set; }
		public bool OneCikanGonderi { get; set; }
		public int OkunmaSayisi { get; set; }
		[StringLength(500)]
		public string MetaKeywords { get; set; }
		public string MetaDescription { get; set; }
		[StringLength(400)]
		public string MetaTitle { get; set; }
		public bool AktifMi { get; set; }

		public string UrunListesi { get; set; }
		public string[] secilenUrunIdleri { get; set; }
		public IEnumerable<BlogKategoriVM> BlogKategoriTipleri { get; set; }

		public IEnumerable<UrunVM> SecilenUrunListesi { get; set; }

		public List<BlogResimVM> BlogResimListesi { get; set; }
		public int TotalCount { get; set; }

		public string KisaIcerikContent { get; set; }
		public string IcerikContent { get; set; }

		public List<UrunVM> Urunler { get; set; }
	}
}
