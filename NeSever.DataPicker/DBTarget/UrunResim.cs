//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataPickerProject.DBTarget
{
    using System;
    using System.Collections.Generic;
    
    public partial class UrunResim
    {
        public int UrunResimId { get; set; }
        public int UrunId { get; set; }
        public string OrjinalResimUrl { get; set; }
        public string ResimUrl { get; set; }
        public byte[] Resim { get; set; }
        public int Sira { get; set; }
        public System.DateTime KayitTarih { get; set; }
        public bool AktifMi { get; set; }
    
        public virtual Urun Urun { get; set; }
    }
}
