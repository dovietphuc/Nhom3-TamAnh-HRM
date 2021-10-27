using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamAnh_HRM.Controllers
{
    public class QuanLyThuong_PhucLoiController : Controller
    {
        // GET: QuanLyThuong_PhucLoi
        public ActionResult QuanLyThuong_PhucLoi()
        {
            ViewBag.Message = "Chức năng quản lý thưởng và phúc lợi";

            return View();
        }
    }
}