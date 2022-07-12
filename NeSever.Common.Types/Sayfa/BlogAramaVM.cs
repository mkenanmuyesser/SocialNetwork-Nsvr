using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class BlogAramaVM
    {

		public int? BlogId { get; set; }
		public int? BlogKategoriId { get; set; }
		public string Baslik { get; set; }
		public string KisaIcerik { get; set; }
		public string YayinTarihi { get; set; }
		public string BaslangicTarihi { get; set; }
		public string BitisTarihi { get; set; }
		public bool OneCikanGonderi { get; set; }	
		public int AktifMi { get; set; }
		public IEnumerable<BlogKategoriVM> BlogKategoriTipleri { get; set; }
		public int draw { get; set; }
		public int start { get; set; }
		public int length { get; set; }


	}
}
