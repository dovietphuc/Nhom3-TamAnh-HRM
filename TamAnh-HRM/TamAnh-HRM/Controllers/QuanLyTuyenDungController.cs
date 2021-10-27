using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamAnh_HRM.Controllers
{
    public class QuanLyTuyenDungController : Controller
    {
        // GET: QuanLyTuyenDung
        public ActionResult QuanLyTuyenDung()
        {
            ViewBag.Message = "Chức năng quản lý tuyển dụng";

            return View();
        }
    }
}