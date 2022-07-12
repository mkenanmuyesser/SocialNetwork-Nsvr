using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{
    public class DataKategoriAramaResultVM
    {
		public int CategoryID { get; set; }
		public int WebSiteID { get; set; }
		public string WebSiteName { get; set; }
		public string OriginalCategoryID { get; set; }
		public int ParentOriginalCategoryID { get; set; }
		public int? TargetCategoryID { get; set; }
		public string TargetCategoryName { get; set; }
		public string CategoryName { get; set; }
		public DateTime LastModifiedDate { get; set; }
		public bool IsActive { get; set; }
        public string Durum { get; set; }

		public int TotalCount { get; set; }
	}
}
