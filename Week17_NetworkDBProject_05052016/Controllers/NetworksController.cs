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
    public class NetworksController : Controller
    {
        private TVNetworkShowsDBEntities db = new TVNetworkShowsDBEntities();

        // GET: Networks
        public ActionResult Index()
        {
            //return View(db.Networks.ToList());
            return View(db.Networks.OrderBy(n => n.Name).ToList());
        }

        // GET: Networks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Network network = db.Networks.Find(id);
            if (network == null)
            {
                return HttpNotFound();
            }
            return View(network);
        }

        // GET: Networks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Networks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NetworkID,Name,Logo")] Network network)
        {
            if (ModelState.IsValid)
            {
                db.Networks.Add(network);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(network);
        }

        // GET: Networks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Network network = db.Networks.Find(id);
            if (network == null)
            {
                return HttpNotFound();
            }
            return View(network);
        }

        // POST: Networks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NetworkID,Name,Logo")] Network network)
        {
            if (ModelState.IsValid)
            {
                db.Entry(network).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(network);
        }

        // GET: Networks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Network network = db.Networks.Find(id);
            if (network == null)
            {
                return HttpNotFound();
            }
            return View(network);
        }

        // POST: Networks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Network network = db.Networks.Find(id);
            db.Networks.Remove(network);
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
