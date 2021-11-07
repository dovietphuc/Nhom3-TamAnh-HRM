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
    public class DM_KTKLController : Controller
    {
        private QuanlynhansuEntities2 db = new QuanlynhansuEntities2();

        // GET: DM_KTKL
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return View(db.tblkhenthuong_kyluat.ToList());
            }
            else
            {
                return RedirectToAction("../Login");
            }
            
        }

        // GET: DM_KTKL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblkhenthuong_kyluat tblkhenthuong_kyluat = db.tblkhenthuong_kyluat.Find(id);
            if (tblkhenthuong_kyluat == null)
            {
                return HttpNotFound();
            }
            return View(tblkhenthuong_kyluat);
        }

        // GET: DM_KTKL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DM_KTKL/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_KTKL_iId,KTKL_sTieuDe,KTKL_dThoiGianLap,KTKL_dThoiGianDuyet,KTKL_iKinhPhi,KTKL_sGhiChu")] tblkhenthuong_kyluat tblkhenthuong_kyluat)
        {
            if (ModelState.IsValid)
            {
                db.tblkhenthuong_kyluat.Add(tblkhenthuong_kyluat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblkhenthuong_kyluat);
        }

        // GET: DM_KTKL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblkhenthuong_kyluat tblkhenthuong_kyluat = db.tblkhenthuong_kyluat.Find(id);
            if (tblkhenthuong_kyluat == null)
            {
                return HttpNotFound();
            }
            return View(tblkhenthuong_kyluat);
        }

        // POST: DM_KTKL/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_KTKL_iId,KTKL_sTieuDe,KTKL_dThoiGianLap,KTKL_dThoiGianDuyet,KTKL_iKinhPhi,KTKL_sGhiChu")] tblkhenthuong_kyluat tblkhenthuong_kyluat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblkhenthuong_kyluat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblkhenthuong_kyluat);
        }

        // GET: DM_KTKL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblkhenthuong_kyluat tblkhenthuong_kyluat = db.tblkhenthuong_kyluat.Find(id);
            if (tblkhenthuong_kyluat == null)
            {
                return HttpNotFound();
            }
            return View(tblkhenthuong_kyluat);
        }

        // POST: DM_KTKL/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblkhenthuong_kyluat tblkhenthuong_kyluat = db.tblkhenthuong_kyluat.Find(id);
            db.tblkhenthuong_kyluat.Remove(tblkhenthuong_kyluat);
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
