using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class SiparisHareket : Entity
    {
        public int SiparisHareketId { get; set; }
        public int SiparisId { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public bool AktifMi { get; set; }

        public virtual Siparis Siparis { get; set; }
    }
}
