using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
	public class BlogIcerikAramaVM
	{
		public bool OneCikanGonderi { get; set; }
		public string BlogKategoriAttribute { get; set; }   
		public string Siralama { get; set; }
		public string AramaKelime { get; set; }
		public int start { get; set; }
		public int length { get; set; }
	}
}
