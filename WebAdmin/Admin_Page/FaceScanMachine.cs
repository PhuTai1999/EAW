//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin_Page
{
    using System;
    using System.Collections.Generic;
    
    public partial class FaceScanMachine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FaceScanMachine()
        {
            this.CheckFaces = new HashSet<CheckFace>();
        }
    
        public int Id { get; set; }
        public string MachineCode { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public string Url { get; set; }
        public string Ip { get; set; }
        public string BrandOfMachine { get; set; }
        public Nullable<System.DateTime> DateOfManufacture { get; set; }
        public bool Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CheckFace> CheckFaces { get; set; }
        public virtual Store Store { get; set; }
    }
}
