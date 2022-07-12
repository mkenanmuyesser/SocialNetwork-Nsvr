using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Admin.AramaVM
{
    public class KullaniciAramaVM
    {
        public string KullaniciAdi { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string DogumBaslangicTarihi { get; set; }
        public string DogumBitisTarihi { get; set; }
        public string UyelikBaslangicTarihi { get; set; }
        public string UyelikBitisTarihi { get; set; }
        public bool AdresVeyaTelefon { get; set; }
        public int Aktiflik { get; set; }
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
    }
}
