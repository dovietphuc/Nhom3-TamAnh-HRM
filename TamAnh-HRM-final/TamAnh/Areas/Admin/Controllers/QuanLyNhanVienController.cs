using StudentManager.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManager.Areas.Admin.Controllers
{
    public class QuanLyNhanVienController : Controller
    {
        // GET: Admin/QuanLyNhanVien
        public ActionResult Index()
        {
            ListNhanVien listNhanVien = new ListNhanVien();
            List<NhanVien> obj = listNhanVien.get();
            return View(obj);
        }

        // GET: Admin/QuanLyNhanVien/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/QuanLyNhanVien/Create
        public ActionResult Create()
        {
            NhanVien_VTCV_Model nhanVien_VTCV_Model = new NhanVien_VTCV_Model();
            return View(nhanVien_VTCV_Model);
        }

        // POST: Admin/QuanLyNhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVien nhanVien)
        {
            try
            {
                // TODO: Add insert logic here
                ListNhanVien listNhanVien = new ListNhanVien();
                listNhanVien.add(nhanVien);
                return RedirectToAction("Index");
            }
            catch
            {
                NhanVien_VTCV_Model nhanVien_VTCV_Model = new NhanVien_VTCV_Model();
                nhanVien_VTCV_Model.NhanVien = nhanVien;
                return View(nhanVien_VTCV_Model);
            }
        }

        // GET: Admin/QuanLyNhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            ListNhanVien listNhanVien = new ListNhanVien();
            List<NhanVien> obj = listNhanVien.get(id);
            return View(obj.FirstOrDefault());
        }

        // POST: Admin/QuanLyNhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(NhanVien nhanVien)
        {
            try
            {
                // TODO: Add update logic here
                ListNhanVien listNhanVien = new ListNhanVien();
                listNhanVien.update(nhanVien);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLyNhanVien/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/QuanLyNhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NhanVien nhanVien)
        {
            try
            {
                // TODO: Add delete logic here
                ListNhanVien listNhanVien = new ListNhanVien();
                listNhanVien.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
