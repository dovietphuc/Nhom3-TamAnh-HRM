using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TamAnh.Models;

namespace TamAnh.Controllers
{
    public class NV_KTKLController : Controller
    {
        private QuanlynhansuEntities2 db = new QuanlynhansuEntities2();

        // GET: NV_KTKL
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                var tblnhanvien_khenthuong_kyluat = db.tblnhanvien_khenthuong_kyluat.Include(t => t.tblkhenthuong_kyluat).Include(t => t.tblnhanvien);
                return View(tblnhanvien_khenthuong_kyluat.ToList());
            }
            else
            {
                return RedirectToAction("../Login");
            }
        }

        // GET: NV_KTKL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnhanvien_khenthuong_kyluat tblnhanvien_khenthuong_kyluat = db.tblnhanvien_khenthuong_kyluat.Find(id);
            if (tblnhanvien_khenthuong_kyluat == null)
            {
                return HttpNotFound();
            }
            return View(tblnhanvien_khenthuong_kyluat);
        }

        // GET: NV_KTKL/Create
        public ActionResult Create()
        {
            ViewBag.FK_KTKL_iId = new SelectList(db.tblkhenthuong_kyluat, "PK_KTKL_iId", "KTKL_sTieuDe");
            ViewBag.FK_NhanVien_iId = new SelectList(db.tblnhanviens, "PK_iIdNhanVien", "NhanVien_sHoVaTen");
            return View();
        }

        // POST: NV_KTKL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_NV_KTKL_iId,FK_NhanVien_iId,FK_KTKL_iId,NVKTKL_sNoiDung")] tblnhanvien_khenthuong_kyluat tblnhanvien_khenthuong_kyluat)
        {
            if (ModelState.IsValid)
            {
                db.tblnhanvien_khenthuong_kyluat.Add(tblnhanvien_khenthuong_kyluat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_KTKL_iId = new SelectList(db.tblkhenthuong_kyluat, "PK_KTKL_iId", "KTKL_sTieuDe", tblnhanvien_khenthuong_kyluat.FK_KTKL_iId);
            ViewBag.FK_NhanVien_iId = new SelectList(db.tblnhanviens, "PK_iIdNhanVien", "NhanVien_sHoVaTen", tblnhanvien_khenthuong_kyluat.FK_NhanVien_iId);
            return View(tblnhanvien_khenthuong_kyluat);
        }

        // GET: NV_KTKL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnhanvien_khenthuong_kyluat tblnhanvien_khenthuong_kyluat = db.tblnhanvien_khenthuong_kyluat.Find(id);
            if (tblnhanvien_khenthuong_kyluat == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_KTKL_iId = new SelectList(db.tblkhenthuong_kyluat, "PK_KTKL_iId", "KTKL_sTieuDe", tblnhanvien_khenthuong_kyluat.FK_KTKL_iId);
            ViewBag.FK_NhanVien_iId = new SelectList(db.tblnhanviens, "PK_iIdNhanVien", "NhanVien_sHoVaTen", tblnhanvien_khenthuong_kyluat.FK_NhanVien_iId);
            return View(tblnhanvien_khenthuong_kyluat);
        }

        // POST: NV_KTKL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_NV_KTKL_iId,FK_NhanVien_iId,FK_KTKL_iId,NVKTKL_sNoiDung")] tblnhanvien_khenthuong_kyluat tblnhanvien_khenthuong_kyluat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblnhanvien_khenthuong_kyluat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_KTKL_iId = new SelectList(db.tblkhenthuong_kyluat, "PK_KTKL_iId", "KTKL_sTieuDe", tblnhanvien_khenthuong_kyluat.FK_KTKL_iId);
            ViewBag.FK_NhanVien_iId = new SelectList(db.tblnhanviens, "PK_iIdNhanVien", "NhanVien_sHoVaTen", tblnhanvien_khenthuong_kyluat.FK_NhanVien_iId);
            return View(tblnhanvien_khenthuong_kyluat);
        }

        // GET: NV_KTKL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblnhanvien_khenthuong_kyluat tblnhanvien_khenthuong_kyluat = db.tblnhanvien_khenthuong_kyluat.Find(id);
            if (tblnhanvien_khenthuong_kyluat == null)
            {
                return HttpNotFound();
            }
            return View(tblnhanvien_khenthuong_kyluat);
        }

        // POST: NV_KTKL/Delete/5
        [HttpPost, ActionName("Delete")]
       // [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblnhanvien_khenthuong_kyluat tblnhanvien_khenthuong_kyluat = db.tblnhanvien_khenthuong_kyluat.Find(id);
            db.tblnhanvien_khenthuong_kyluat.Remove(tblnhanvien_khenthuong_kyluat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
