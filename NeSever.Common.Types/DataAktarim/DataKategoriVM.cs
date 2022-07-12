using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.DataAktarim
{
    public class DataKategoriVM
    {
        public int CategoryID { get; set; }
		public int WebSiteID { get; set; }
		public string WebSiteName { get; set; }
		public int OriginalCategoryID { get; set; }
		public int ParentOriginalCategoryID { get; set; }
		public int TargetCategoryID { get; set; }
		public string CategoryName { get; set; }
		public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

	}
}
