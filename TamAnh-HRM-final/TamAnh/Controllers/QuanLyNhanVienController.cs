using TamAnh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamAnh.Controllers
{
    public class QuanLyNhanVienController : Controller
    {
        // GET: Admin/QuanLyNhanVien
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                ListNhanVien listNhanVien = new ListNhanVien();
                List<NhanVien> obj = listNhanVien.get();
                return View(obj);
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // GET: Admin/QuanLyNhanVien/Details/5
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

        // GET: Admin/QuanLyNhanVien/Create
        public ActionResult Create()
        {
            if (Session["username"] != null)
            {
                NhanVien_VTCV_Model nhanVien_VTCV_Model = new NhanVien_VTCV_Model();
                return View(nhanVien_VTCV_Model);
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // POST: Admin/QuanLyNhanVien/Create
        [HttpPost]
        public ActionResult Create(NhanVien nhanVien)
        {
            if (Session["username"] != null)
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
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // GET: Admin/QuanLyNhanVien/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["username"] != null)
            {
                ListNhanVien listNhanVien = new ListNhanVien();
                List<NhanVien> obj = listNhanVien.get(id);
                return View(obj.FirstOrDefault());
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // POST: Admin/QuanLyNhanVien/Edit/5
        [HttpPost]
        public ActionResult Edit(NhanVien nhanVien)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add update logic here
                    ListNhanVien listNhanVien = new ListNhanVien();
                    NhanVien old = listNhanVien.get(nhanVien.ID).FirstOrDefault();
                    nhanVien.iMaVTCV = old.iMaVTCV;
                    if (listNhanVien.update(nhanVien))
                    {
                        return RedirectToAction("Index");
                    } else
                    {
                        return View(nhanVien);
                    }
                }
                catch
                {
                    return View(nhanVien);
                }
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // GET: Admin/QuanLyNhanVien/Delete/5
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

        // POST: Admin/QuanLyNhanVien/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, NhanVien nhanVien)
        {
            if (Session["username"] != null)
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
            else
            {
                return RedirectToAction("../Login");
            }

        }
    }
}
