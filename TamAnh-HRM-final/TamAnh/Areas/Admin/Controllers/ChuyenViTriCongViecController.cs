using StudentManager.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManager.Areas.Admin.Controllers
{
    public class ChuyenViTriCongViecController : Controller
    {
        // GET: Admin/ChuyenViTriCongViec
        public ActionResult Index()
        {
            ListQuyetDinhThuyenChuyen list = new ListQuyetDinhThuyenChuyen();
            return View(list.get());
        }

        // GET: Admin/ChuyenViTriCongViec/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ChuyenViTriCongViec/Create
        public ActionResult Create()
        {
            QuyetDinh_VTCV_NhanVien_Model obj = new QuyetDinh_VTCV_NhanVien_Model();            
            return View(obj);
        }

        // POST: Admin/ChuyenViTriCongViec/Create
        [HttpPost]
        public ActionResult Create(QuyetDinh_VTCV_NhanVien_Model quyetDinh)
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

        // GET: Admin/ChuyenViTriCongViec/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/ChuyenViTriCongViec/Edit/5
        [HttpPost]
        public ActionResult Edit(QuyetDinhThuyenChuyen quyetDinh)
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

        // GET: Admin/ChuyenViTriCongViec/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ChuyenViTriCongViec/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, QuyetDinhThuyenChuyen quyetDinh)
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

        // GET: Admin/ChuyenViTriCongViec/Aproved/5
        public ActionResult Aproved(int id)
        {
            return View();
        }

        // POST: Admin/ChuyenViTriCongViec/Aproved/5
        [HttpPost]
        public ActionResult Aproved(int id, QuyetDinhThuyenChuyen quyetDinh)
        {
            try
            {
                // TODO: Add delete logic here
                ListQuyetDinhThuyenChuyen listQuyetDinh = new ListQuyetDinhThuyenChuyen();
                listQuyetDinh.aproved(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Admin/ChuyenViTriCongViec/NotAproved/5
        public ActionResult NotAproved(int id)
        {
            return View();
        }

        // POST: Admin/ChuyenViTriCongViec/NotAproved/5
        [HttpPost]
        public ActionResult NotAproved(int id, QuyetDinhThuyenChuyen quyetDinh)
        {
            try
            {
                // TODO: Add delete logic here
                ListQuyetDinhThuyenChuyen listQuyetDinh = new ListQuyetDinhThuyenChuyen();
                listQuyetDinh.notAproved(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
