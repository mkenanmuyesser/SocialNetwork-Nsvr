using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class ArkadasAraSonucVM
    {
        public Guid ArkadasKullaniciId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }

        public string KullaniciAdi { get; set; }
        //public KullaniciResimVM KullaniciResim { get; set; }

    }
}
