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
    public class NV_CCController : Controller
    {
        private QuanlynhansuEntities2 db = new QuanlynhansuEntities2();

        // GET: NV_CC
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                var tblchungchis = db.tblchungchis.Include(t => t.tblnhanvien);
                return View(tblchungchis.ToList());
            }
            else
            {
                return RedirectToAction("../Login");
            }
           
        }

        // GET: NV_CC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblchungchi tblchungchi = db.tblchungchis.Find(id);
            if (tblchungchi == null)
            {
                return HttpNotFound();
            }
            return View(tblchungchi);
        }

        // GET: NV_CC/Create
        public ActionResult Create()
        {
            ViewBag.FK_NhanVien_iIDNhanVien = new SelectList(db.tblnhanviens, "PK_iIdNhanVien", "NhanVien_sHoVaTen");
            return View();
        }

        // POST: NV_CC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_ChungChi_iMaCC,ChungChi_sTenChungChi,ChungChi_dNgayBD,ChungChi_dNgayKT,ChungChi_sTepDinhKem,FK_NhanVien_iIDNhanVien")] tblchungchi tblchungchi)
        {
            if (ModelState.IsValid)
            {
                db.tblchungchis.Add(tblchungchi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_NhanVien_iIDNhanVien = new SelectList(db.tblnhanviens, "PK_iIdNhanVien", "NhanVien_sHoVaTen", tblchungchi.FK_NhanVien_iIDNhanVien);
            return View(tblchungchi);
        }

        // GET: NV_CC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblchungchi tblchungchi = db.tblchungchis.Find(id);
            if (tblchungchi == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_NhanVien_iIDNhanVien = new SelectList(db.tblnhanviens, "PK_iIdNhanVien", "NhanVien_sHoVaTen", tblchungchi.FK_NhanVien_iIDNhanVien);
            return View(tblchungchi);
        }

        // POST: NV_CC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_ChungChi_iMaCC,ChungChi_sTenChungChi,ChungChi_dNgayBD,ChungChi_dNgayKT,ChungChi_sTepDinhKem,FK_NhanVien_iIDNhanVien")] tblchungchi tblchungchi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblchungchi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_NhanVien_iIDNhanVien = new SelectList(db.tblnhanviens, "PK_iIdNhanVien", "NhanVien_sHoVaTen", tblchungchi.FK_NhanVien_iIDNhanVien);
            return View(tblchungchi);
        }

        // GET: NV_CC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblchungchi tblchungchi = db.tblchungchis.Find(id);
            if (tblchungchi == null)
            {
                return HttpNotFound();
            }
            return View(tblchungchi);
        }

        // POST: NV_CC/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblchungchi tblchungchi = db.tblchungchis.Find(id);
            db.tblchungchis.Remove(tblchungchi);
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
