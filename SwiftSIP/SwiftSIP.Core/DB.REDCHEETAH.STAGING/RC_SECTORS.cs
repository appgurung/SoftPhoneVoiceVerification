//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoftPhone.Core.DB.REDCHEETAH.STAGING
{
    using System;
    using System.Collections.Generic;
    
    public partial class RC_SECTORS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RC_SECTORS()
        {
            this.RC_CHANNELS = new HashSet<RC_CHANNELS>();
        }
    
        public int SECTOR_ID { get; set; }
        public string SECTOR_NAME { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RC_CHANNELS> RC_CHANNELS { get; set; }
    }
}
