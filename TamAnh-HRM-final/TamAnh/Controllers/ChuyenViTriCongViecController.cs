using TamAnh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamAnh.Controllers
{
    public class ChuyenViTriCongViecController : Controller
    {
        // GET: Admin/ChuyenViTriCongViec
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                ListQuyetDinhThuyenChuyen list = new ListQuyetDinhThuyenChuyen();
                return View(list.get());
            }
            else
            {
                return RedirectToAction("../Login");
            }
        }

        // GET: Admin/ChuyenViTriCongViec/Details/5
        public ActionResult Details(int id)
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // GET: Admin/ChuyenViTriCongViec/Create
        public ActionResult Create()
        {
            if (Session["username"] != null)
            {
                QuyetDinh_VTCV_NhanVien_Model obj = new QuyetDinh_VTCV_NhanVien_Model();
                return View(obj);
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // POST: Admin/ChuyenViTriCongViec/Create
        [HttpPost]
        public ActionResult Create(QuyetDinh_VTCV_NhanVien_Model quyetDinh)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add insert logic here
                    ListQuyetDinhThuyenChuyen list = new ListQuyetDinhThuyenChuyen();
                    quyetDinh.QuyetDinhThuyenChuyen.iTrangThai = ListQuyetDinhThuyenChuyen.STATE_WAITING;
                    quyetDinh.QuyetDinhThuyenChuyen.dThoiGianLap = DateTime.Now;
                    quyetDinh.QuyetDinhThuyenChuyen.dThoiGianDuyet = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                    quyetDinh.QuyetDinhThuyenChuyen.iMaVTCV_Cu = new ListNhanVien().get(quyetDinh.QuyetDinhThuyenChuyen.iMaNVLap).FirstOrDefault().iMaVTCV;
                    list.add(quyetDinh.QuyetDinhThuyenChuyen);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    QuyetDinh_VTCV_NhanVien_Model obj = quyetDinh;
                    return View(obj);
                }
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // GET: Admin/ChuyenViTriCongViec/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // POST: Admin/ChuyenViTriCongViec/Edit/5
        [HttpPost]
        public ActionResult Edit(QuyetDinhThuyenChuyen quyetDinh)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // GET: Admin/ChuyenViTriCongViec/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // POST: Admin/ChuyenViTriCongViec/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, QuyetDinhThuyenChuyen quyetDinh)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // GET: Admin/ChuyenViTriCongViec/Aproved/5
        public ActionResult Aproved(int id)
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // POST: Admin/ChuyenViTriCongViec/Aproved/5
        [HttpPost]
        public ActionResult Aproved(int id, QuyetDinhThuyenChuyen quyetDinh)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    ListQuyetDinhThuyenChuyen listQuyetDinh = new ListQuyetDinhThuyenChuyen();
                    quyetDinh = listQuyetDinh.get(id).FirstOrDefault();
                    quyetDinh.iMaNVDuyet = (int) Session["user_id"];
                    listQuyetDinh.aproved(quyetDinh);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // GET: Admin/ChuyenViTriCongViec/NotAproved/5
        public ActionResult NotAproved(int id)
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // POST: Admin/ChuyenViTriCongViec/NotAproved/5
        [HttpPost]
        public ActionResult NotAproved(int id, QuyetDinhThuyenChuyen quyetDinh)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    ListQuyetDinhThuyenChuyen listQuyetDinh = new ListQuyetDinhThuyenChuyen();
                    quyetDinh = listQuyetDinh.get(id).FirstOrDefault();
                    quyetDinh.iMaNVDuyet = (int) Session["user_id"];
                    listQuyetDinh.notAproved(quyetDinh);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }
    }
}
