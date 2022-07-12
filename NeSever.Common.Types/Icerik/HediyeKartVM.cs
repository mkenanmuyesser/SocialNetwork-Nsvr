using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Icerik
{
    public class HediyeKartVM
    {
        public int HediyeKartId { get; set; }
        public string HediyeKartAdi { get; set; }
        public string Aciklama { get; set; }

        public int Sira { get; set; }
        public string AciklamaContent { get; set; }
        public byte[] Dosya { get; set; }
        public string DosyaAdi { get; set; }
        public string Resim { get; set; }
        public byte[] KucukDosya { get; set; }
        public string KucukDosyaAdi { get; set; }
        public string KucukResim { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool AktifMi { get; set; }
        public int HediyeKartKategoriId { get; set; }

        public IEnumerable<HediyeKartKategoriVM> HediyeKartKategoriTipleri { get; set; } 
    }



}
