//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TamAnh.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblchungchi
    {
        public int PK_ChungChi_iMaCC { get; set; }
        public string ChungChi_sTenChungChi { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ChungChi_dNgayBD { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ChungChi_dNgayKT { get; set; }
        public string ChungChi_sTepDinhKem { get; set; }
        public int FK_NhanVien_iIDNhanVien { get; set; }
    
        public virtual tblnhanvien tblnhanvien { get; set; }
    }
}
