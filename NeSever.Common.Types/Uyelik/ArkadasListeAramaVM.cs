using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasListeAramaVM
    {
		public string Siralama { get; set; }
		public string AramaKelime { get; set; }
		public int start { get; set; }
		public int length { get; set; }
		public TokenVM Token { get; set; }
	}
}
