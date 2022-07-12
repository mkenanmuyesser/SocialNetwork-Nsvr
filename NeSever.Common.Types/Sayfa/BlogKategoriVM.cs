using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeSever.Common.Models.Sayfa
{
    public class BlogKategoriVM
    {
        public int BlogKategoriId { get; set; }
        [StringLength(50)]
        public string BlogKategoriAdi { get; set; }
        [StringLength(50)]
        public string BlogKategoriAttribute { get; set; }
        [StringLength(250)]
        public string Aciklama { get; set; }
        [StringLength(250)]
        public string AciklamaContent { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public List<string> Resimler { get; set; }

        public List<BlogKategoriResimVM> BlogKategoriResimListesi { get; set; }
    }
}
