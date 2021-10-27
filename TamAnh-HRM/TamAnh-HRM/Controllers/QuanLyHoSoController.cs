using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamAnh_HRM.Controllers
{
    public class QuanLyHoSoController : Controller
    {
        // GET: QuanLyHoSo
        public ActionResult QuanLyHoSo()
        {
            ViewBag.Message = "Chức năng quản lý hồ sơ";

            return View();
        }

        public ActionResult CapNhatSoYeuLyLich()
        {
            ViewBag.Message = "Chức năng cập nhật sơ yếu lý lịch";

            return View();
        }

        public ActionResult ChuyenViTriCongViec()
        {
            ViewBag.Message = "Chức năng chuyển vị trí công việc";

            return View();
        }

        public ActionResult QuanLyHopDongLaoDong()
        {
            ViewBag.Message = "Chức năng quản lý hợp đồng lao động";

            return View();
        }

        public ActionResult QuanLyChungChi()
        {
            ViewBag.Message = "Chức năng quản lý chứng chỉ";

            return View();
        }

        public ActionResult QuanLyKhenThuong()
        {
            ViewBag.Message = "Chức năng quản lý khen thưởng";

            return View();
        }

        public ActionResult BaoCaoNhanSu()
        {
            ViewBag.Message = "Chức năng báo cáo tình hình nhân sự";

            return View();
        }

    }
}