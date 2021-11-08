using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamAnh.Models
{
    public class HopDong_NhanVien_Model
    {
        public HopDong HopDong { get; set; }
        public List<SelectListItem> NhanViens
        {
            get
            {
                List<NhanVien> list = new ListNhanVien().get();
                List<SelectListItem> listSelect = new List<SelectListItem>();
                foreach (var item in list)
                {
                    listSelect.Add(new SelectListItem { Text = item.ID + " - " + item.sTenNhanVien, Value = item.ID.ToString() });
                }
                return listSelect;
            }
        }
    }
}