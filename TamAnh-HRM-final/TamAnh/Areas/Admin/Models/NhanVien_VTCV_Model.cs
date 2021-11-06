using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManager.Areas.Admin.Models
{
    public class NhanVien_VTCV_Model
    {
        public NhanVien NhanVien { get; set; }
        public List<SelectListItem> ViTriCongViecs {
            get
            {
                List<ViTriCongViec> listVTCV = new ListViTri().get();
                List<SelectListItem> listSelect = new List<SelectListItem>();
                foreach(var item in listVTCV)
                {
                    listSelect.Add(new SelectListItem { Text = item.sTenViTri + " - " + item.sTenBoPhan, Value = item.ID.ToString() });
                }
                return listSelect;
            }
        }
    }
}