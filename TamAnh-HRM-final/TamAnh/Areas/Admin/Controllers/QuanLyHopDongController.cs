﻿using StudentManager.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManager.Areas.Admin.Controllers
{
    public class QuanLyHopDongController : Controller
    {
        // GET: Admin/QuanLyHopDong
        public ActionResult Index()
        {
            ListHopDong listHopDong = new ListHopDong();
            List<HopDong> obj = listHopDong.get();
            return View(obj);
        }

        // GET: Admin/QuanLyHopDong/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/QuanLyHopDong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuanLyHopDong/Create
        [HttpPost]
        public ActionResult Create(HopDong hopDong)
        {
            try
            {
                // TODO: Add insert logic here
                ListHopDong listHopDong = new ListHopDong();
                listHopDong.add(hopDong);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Admin/QuanLyHopDong/Edit/5
        public ActionResult Edit(int ID)
        {
            ListHopDong listHopDong = new ListHopDong();
            List<HopDong> obj = listHopDong.get(ID);
            return View(obj.FirstOrDefault());
        }

        // POST: Admin/QuanLyHopDong/Edit/5
        [HttpPost]
        public ActionResult Edit(HopDong hopDong)
        {
            try
            {
                // TODO: Add update logic here
                ListHopDong listHopDong = new ListHopDong();
                listHopDong.update(hopDong);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/QuanLyHopDong/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/QuanLyHopDong/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, HopDong hopDong)
        {
            try
            {
                // TODO: Add delete logic here
                ListHopDong listHopDong = new ListHopDong();
                listHopDong.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}