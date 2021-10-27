using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamAnh_HRM.Controllers
{
    public class QuanLyChamCongController : Controller
    {
        // GET: QuanLyChamCong
        public ActionResult QuanLyChamCong()
        {
            ViewBag.Message = "Chức năng quản lý châm công";

            return View();
        }
    }
}