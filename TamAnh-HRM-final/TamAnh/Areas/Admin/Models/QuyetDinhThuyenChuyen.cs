using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManager.Areas.Admin.Models
{
    public class QuyetDinhThuyenChuyen
    {
        public int ID { set; get; }

        [Display(Name = "Thời gian lập")]
        public DateTime dThoiGianLap { get; set; }

        [Display(Name = "Thời gian duyệt")]
        public DateTime dThoiGianDuyet { set; get; }

        [Required(ErrorMessage = "Nhân viên lập không được để trống")]
        [Display(Name = "Mã nhân viên lập")]
        public int iMaNVLap { get; set; }

        [Display(Name = "Nhân viên lập")]
        public string sTenNVLap { get; set; }

        [Required(ErrorMessage = "Nhân viên duyệt không được để trống")]
        [Display(Name = "Max nhân viên lập")]
        public int iMaNVDuyet { get; set; }

        [Display(Name = "Nhân viên duyệt")]
        public string sTenNVDuyet { get; set; }

        [Required(ErrorMessage = "Vị trí công việc cũ không được để trống")]
        [Display(Name = "Mã vị trí công việc cũ")]
        public int iMaVTCV_Cu { get; set; }

        [Display(Name = "Vị trí công việc cũ")]
        public string sTenVTCV_Cu { get; set; }

        [Required(ErrorMessage = "Vị trí công việc mới không được để trống")]
        [Display(Name = "Mã vị trí công việc mới")]
        public int iMaVTCV_Moi { get; set; }

        [Display(Name = "Vị trí công việc mới")]
        public string sTenVTCV_Moi { get; set; }

        [Display(Name = "Lý do")]
        public string sLyDo { get; set; }

        [Display(Name = "Trạng thái")]
        public int iTrangThai { get; set; }

    }
}