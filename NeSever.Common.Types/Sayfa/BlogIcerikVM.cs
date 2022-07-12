using NeSever.Common.Models.Urun;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{

	public class BlogIcerikVM
	{
        public int BlogId { get; set; }
        public int BlogKategoriId { get; set; }
		public string BlogKategoriAdi { get; set; }
		public string BlogKategoriAttribute { get; set; }
		public string Baslik { get; set; }
		public string KisaIcerik { get; set; }
		public string Icerik { get; set; }
        public string ResimBase64 { get; set; }
        public string Etiketler { get; set; }
		public string YayinTarihi { get; set; }
        public string BaslangicTarihi { get; set; }
		public string BitisTarihi { get; set; }
		public bool OneCikanGonderi { get; set; }
		public int OkunmaSayisi { get; set; }
		public IEnumerable<UrunIcerikVM> SecilenUrunListesi { get; set; }
		public List<BlogResimVM> BlogResimListesi { get; set; }
	}
}
