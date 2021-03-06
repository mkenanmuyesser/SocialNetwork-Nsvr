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
    
    public partial class DataKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataKategori()
        {
            this.DataUrunKategori = new HashSet<DataUrunKategori>();
        }
    
        public int CategoryID { get; set; }
        public int WebSiteID { get; set; }
        public string OriginalCategoryID { get; set; }
        public string ParentOriginalCategoryID { get; set; }
        public Nullable<int> TargetCategoryID { get; set; }
        public string CategoryName { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    
        public virtual WebSite WebSite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DataUrunKategori> DataUrunKategori { get; set; }
    }
}
