using TamAnh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamAnh.Controllers
{
    public class QuanLyHopDongController : Controller
    {
        // GET: Admin/QuanLyHopDong
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                ListHopDong listHopDong = new ListHopDong();
                List<HopDong> obj = listHopDong.get();
                return View(obj);
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // GET: Admin/QuanLyHopDong/Details/5
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

        // GET: Admin/QuanLyHopDong/Create
        public ActionResult Create()
        {
            if (Session["username"] != null)
            {
                HopDong_NhanVien_Model obj = new HopDong_NhanVien_Model();
                return View(obj);
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // POST: Admin/QuanLyHopDong/Create
        [HttpPost]
        public ActionResult Create(HopDong hopDong)
        {
            if (Session["username"] != null)
            {
                try
                {
                    // TODO: Add insert logic here
                    ListHopDong listHopDong = new ListHopDong();
                    listHopDong.add(hopDong);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    HopDong_NhanVien_Model obj = new HopDong_NhanVien_Model();
                    obj.HopDong = hopDong;
                    return View(obj);
                }
            }
            else
            {
                return RedirectToAction("../Login");
            }

        }

        // GET: Admin/QuanLyHopDong/Edit/5
        public ActionResult Edit(int ID)
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

        // POST: Admin/QuanLyHopDong/Edit/5
        [HttpPost]
        public ActionResult Edit(HopDong hopDong)
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

        // GET: Admin/QuanLyHopDong/Delete/5
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

        // POST: Admin/QuanLyHopDong/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, HopDong hopDong)
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
    }
}
