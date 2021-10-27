using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamAnh_HRM.Controllers
{
    public class QuanLyHeThongController : Controller
    {
        // GET: QuanLyHeThong
        public ActionResult QuanLyHeThong()
        {
            ViewBag.Message = "Chức năng quản lý hệ thống";

            return View();
        }
    }
}