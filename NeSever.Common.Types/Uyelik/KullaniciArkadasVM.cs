using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class KullaniciArkadasVM
    {    

        public KullaniciArkadasVM()
        {
            Arkadaslar = new List<ArkadasVM>();
        }

        public int ArkadasSayisi  { get; set; }

        public List<ArkadasVM> Arkadaslar { get; set; }
    }
}
