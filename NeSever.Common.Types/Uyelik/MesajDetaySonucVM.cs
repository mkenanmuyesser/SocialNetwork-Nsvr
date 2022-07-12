using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeSever.Common.Models.Uyelik
{
    public class MesajDetaySonucVM
    {
        public int MesajId { get; set; }
        public KullaniciVM GonderenKullanici { get; set; }
        public KullaniciVM AliciKullanici { get; set; }
        public DateTime KayitTarihi { get; set; }
        public string Mesaj { get; set; }
    }
}
