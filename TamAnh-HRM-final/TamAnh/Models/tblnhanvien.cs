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
    
    public partial class tblnhanvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblnhanvien()
        {
            this.tblnhanvien_khenthuong_kyluat = new HashSet<tblnhanvien_khenthuong_kyluat>();
            this.tblchungchis = new HashSet<tblchungchi>();
            this.tbltaikhoans = new HashSet<tbltaikhoan>();
        }
        
        public int PK_iIdNhanVien { get; set; }
        public string NhanVien_sHoVaTen { get; set; }
        public System.DateTime NhanVien_sNgaySinh { get; set; }
        public bool NhanVien_bGioiTinh { get; set; }
        public string NhanVien_sDiaChi { get; set; }
        public string NhanVien_sDienThoai { get; set; }
        public string NhanVien_sBangCap { get; set; }
        public string NhanVien_sCMT { get; set; }
        public int FK_VCCV_iMaVCCV { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblnhanvien_khenthuong_kyluat> tblnhanvien_khenthuong_kyluat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblchungchi> tblchungchis { get; set; }
        public virtual tblvitricongviec tblvitricongviec { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbltaikhoan> tbltaikhoans { get; set; }
    }
}
