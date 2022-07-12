using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.Data.Entities
{
    public partial class HediyeKartKategori : Entity
    {
        public HediyeKartKategori()
        {
            HediyeKart = new HashSet<HediyeKart>();
        }
        public int HediyeKartKategoriId { get; set; }
        public string HediyeKartKategoriAdi { get; set; }
        public string HediyeKartKategoriAttribute { get; set; }
        public int Sira { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<HediyeKart> HediyeKart { get; set; }
    }
}