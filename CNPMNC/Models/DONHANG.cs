//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNPMNC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            this.CTDONHANGs = new HashSet<CTDONHANG>();
            this.PHIs = new HashSet<PHI>();
        }
    
        public string IDDonHang { get; set; }
        public string NoiDi { get; set; }
        public string NoiDen { get; set; }
        public Nullable<int> CanNang { get; set; }
        public string HinhThucVanChuyen { get; set; }
        public string TrangThai { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHI> PHIs { get; set; }
    }
}
