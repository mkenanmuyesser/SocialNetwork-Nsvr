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
    
    public partial class DataHataLog
    {
        public int ErrorLogID { get; set; }
        public int WebSiteID { get; set; }
        public string ProcessName { get; set; }
        public string ErrorLogContent { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
    
        public virtual WebSite WebSite { get; set; }
    }
}