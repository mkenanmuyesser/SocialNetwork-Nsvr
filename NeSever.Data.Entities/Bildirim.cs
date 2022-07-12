using NeSever.Common.Infra.DataLayer.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeSever.Data.Entities
{
    public partial class Bildirim : Entity
    {   
        [Key]
        public int BildirimId { get; set; }
        public Guid KullaniciId { get; set; }
        public int BildirimTipId { get; set; }
        public string BildirimIcerik { get; set; }
        public DateTime KayitTarihi { get; set; }
        public bool OkunduMu { get; set; }
        public bool AktifMi { get; set; }

        public virtual BildirimTip BildirimTip { get; set; }
        public virtual Kullanici Kullanici { get; set; }
    }
}
