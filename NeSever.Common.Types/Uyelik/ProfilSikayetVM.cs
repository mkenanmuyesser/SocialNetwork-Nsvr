using System;
using System.ComponentModel.DataAnnotations;

namespace NeSever.Common.Models.Uyelik
{
    public class ProfilSikayetVM
    {
        public Guid SikayetEdilenKullaniciId { get; set; }
        public Guid? SikayetEdenKullaniciId { get; set; }
        [Required]
        [StringLength(250)]
        public string SikayetSebebi { get; set; }        
    }
}
