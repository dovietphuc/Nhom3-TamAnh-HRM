using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManager.Areas.Admin.Models
{
    public class QuyetDinh_VTCV_NhanVien_Model
    {
        public QuyetDinhThuyenChuyen QuyetDinhThuyenChuyen { get; set; }

        public List<SelectListItem> ViTriCongViecs
        {
            get
            {
                List<ViTriCongViec> listVTCV = new ListViTri().get();
                List<SelectListItem> listSelect = new List<SelectListItem>();
                foreach (var item in listVTCV)
                {
                    listSelect.Add(new SelectListItem { Text = item.sTenViTri + " - " + item.sTenBoPhan, Value = item.ID.ToString() });
                }
                return listSelect;
            }
        }

        public List<SelectListItem> NhanViens
        {
            get
            {
                List<NhanVien> list = new ListNhanVien().get();
                List<SelectListItem> listSelect = new List<SelectListItem>();
                foreach (var item in list)
                {
                    listSelect.Add(new SelectListItem { Text = item.ID + " - " + item.sTenNhanVien + " - " + item.sTenVTCV + " - " + item.viTriCongViec.sTenBoPhan, Value = item.ID.ToString() });
                }
                return listSelect;
            }
        }
    }
}