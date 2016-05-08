﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week17_NetworkDBProject_05052016.Models;

namespace Week17_NetworkDBProject_05052016.Controllers
{
    public class vwRatingsAbove4Controller : Controller
    {
        private TVNetworkShowsDBEntities1 db = new TVNetworkShowsDBEntities1();

        // GET: vwRatingsAbove4
        public ActionResult Index()
        {
            return View(db.vwRatingsAbove4.ToList());
        }

        // GET: vwRatingsAbove4/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwRatingsAbove4 vwRatingsAbove4 = db.vwRatingsAbove4.Find(id);
            if (vwRatingsAbove4 == null)
            {
                return HttpNotFound();
            }
            return View(vwRatingsAbove4);
        }

        // GET: vwRatingsAbove4/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vwRatingsAbove4/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowID,NetworkID,Title,Genre,Rating,Photo,Website,Description")] vwRatingsAbove4 vwRatingsAbove4)
        {
            if (ModelState.IsValid)
            {
                db.vwRatingsAbove4.Add(vwRatingsAbove4);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vwRatingsAbove4);
        }

        // GET: vwRatingsAbove4/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwRatingsAbove4 vwRatingsAbove4 = db.vwRatingsAbove4.Find(id);
            if (vwRatingsAbove4 == null)
            {
                return HttpNotFound();
            }
            return View(vwRatingsAbove4);
        }

        // POST: vwRatingsAbove4/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowID,NetworkID,Title,Genre,Rating,Photo,Website,Description")] vwRatingsAbove4 vwRatingsAbove4)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vwRatingsAbove4).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vwRatingsAbove4);
        }

        // GET: vwRatingsAbove4/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwRatingsAbove4 vwRatingsAbove4 = db.vwRatingsAbove4.Find(id);
            if (vwRatingsAbove4 == null)
            {
                return HttpNotFound();
            }
            return View(vwRatingsAbove4);
        }

        // POST: vwRatingsAbove4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vwRatingsAbove4 vwRatingsAbove4 = db.vwRatingsAbove4.Find(id);
            db.vwRatingsAbove4.Remove(vwRatingsAbove4);
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
