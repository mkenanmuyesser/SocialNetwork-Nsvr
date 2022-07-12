using System;

namespace NeSever.Common.Models.Urun
{
    public class UrunAramaResultVM
    {
		public int TotalCount { get; set; }
		public int UrunId { get; set; }
		public string Sku { get; set; }
		public string UrunAdi { get; set; }
		public string KisaAciklama { get; set; }
		public string Aciklama { get; set; }
		public string AdresUrl { get; set; }
		public bool AnasayfadaGoster { get; set; }
		public DateTime KayitTarih { get; set; }
		public DateTime GuncellemeTarih { get; set; }
		public int Sira { get; set; }
		public string Durum { get; set; }

		public string AnasayfadaGosterDurum { get; set; }

		public string ResimUrl { get; set; }

        public string KategoriAdi { get; set; }


    }
}
