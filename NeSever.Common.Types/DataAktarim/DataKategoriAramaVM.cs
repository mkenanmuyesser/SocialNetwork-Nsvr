using NeSever.Common.Models.Urun;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{
    public class DataKategoriAramaVM
    {
		public int? CategoryID { get; set; }
		public int? WebSiteID { get; set; }
		public string WebSiteName { get; set; }
		public string CategoryName { get; set; }
		public int IsActive { get; set; }
		public int draw { get; set; }
		public int start { get; set; }
		public int length { get; set; }

		public IEnumerable<WebSiteAramaSonucVM> WebSiteListesi { get; set; }
		public IEnumerable<KategoriVM> KategoriListesi { get; set; }
	}
}
