using NeSever.Common.Infra.DataLayer.Entity;
using System;

namespace NeSever.Data.Entities
{
    public partial class ProfilSikayet : Entity
    {
        public int ProfilSikayetId { get; set; }
        public Guid SikayetEdilenKullaniciId { get; set; }
        public Guid? SikayetEdenKullaniciId { get; set; }
        public string SikayetSebebi { get; set; }
        public DateTime Tarih { get; set; }
        public bool AktifMi { get; set; }

        public virtual Kullanici SikayetEdilenKullanici { get; set; }
        public virtual Kullanici SikayetEdenKullanici { get; set; }
    }
}
