using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.Collections.Generic;

namespace NeSever.Data.Entities
{
    public partial class KullaniciMesaj : Entity
    {
        public int KullaniciMesajId { get; set; }
        public Guid GondericiKullaniciId { get; set; }
        public Guid AliciKullaniciId { get; set; }
        public bool GonderenAktifMi { get; set; }
        public bool AlanAktifMi { get; set; }        
        public string MesajIcerik { get; set; }
        public DateTime KayitTarih { get; set; }
        public bool OkunduMu { get; set; }
        public bool AktifMi { get; set; }
        public virtual Kullanici AliciKullanici { get; set; }
        public virtual Kullanici GondericiKullanici { get; set; }
    }
}
