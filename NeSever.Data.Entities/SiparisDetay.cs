﻿using NeSever.Common.Infra.DataLayer.Entity;

namespace NeSever.Data.Entities
{
    public partial class SiparisDetay : Entity
    {
        public int SiparisDetayId { get; set; }
        public int SiparisId { get; set; }
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public decimal UrunBirimKdvDahilTutar { get; set; }
        public decimal UrunBirimKdvHaricTutar { get; set; }
        public decimal UrunBirimKdvTutar { get; set; }
        public decimal HesaplananBirimKdvDahilTutar { get; set; }
        public decimal HesaplananBirimKdvHaricTutar { get; set; }
        public decimal HesaplananBirimKdvTutar { get; set; }
        public decimal HesaplananKdvDahilTutar { get; set; }
        public decimal HesaplananKdvHaricTutar { get; set; }
        public decimal HesaplananKdvTutar { get; set; }
        public bool AktifMi { get; set; }

        public virtual Siparis Siparis { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
