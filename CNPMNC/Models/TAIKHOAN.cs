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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class TAIKHOAN
    {
        public string IDTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public Nullable<int> MatKhau { get; set; }
        public Nullable<int> LoaiTaiKhoan { get; set; }
        [NotMapped]
        [DisplayName("Nh?p L?i M?t Kh?u")]
        public string ConfirmPass { get; set; }
        [NotMapped]
        public string ErrorLogin { get; set; }
    }
}