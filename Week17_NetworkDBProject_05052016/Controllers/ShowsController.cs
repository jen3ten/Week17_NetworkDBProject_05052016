using System;
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
    public class ShowsController : Controller
    {
        private TVNetworkShowsDBEntities db = new TVNetworkShowsDBEntities();

        // GET: Shows
        public ActionResult Index(int? network, string sortBy)
        {
            if (network == 0)
            {
                //return View(db.Shows.OrderBy(x => x.Title).Where(x => x.NetworkID == network).ToList());
                var shows = db.Shows.Include(s => s.Network);
                return View(shows.OrderBy(x => x.Title).ToList());

            }
            else if (network >= 1)
            {
                return View(db.Shows.OrderBy(x => x.Title).Where(x => x.NetworkID == network).ToList());
            }
            else
            {
                var shows = db.Shows.Include(s => s.Network);
                switch (sortBy)
                {
                    case "Title":
                        return View(shows.OrderBy(x => x.Title).ToList());
                    case "Genre":
                        return View(shows.OrderBy(x => x.Genre).ToList());
                    case "Rating":
                        return View(shows.OrderBy(x => x.Rating).ToList());
                    case "Network":
                        return View(shows.OrderBy(x => x.Network.Name).ToList());
                    default:
                        return View(shows.OrderBy(x => x.Title).ToList());
                }
            }
        }

        public ActionResult Sort(string sortBy)
        {
                var shows = db.Shows.Include(s => s.Network);
                return View(shows.OrderBy(x => x.Title).ToList());
        }


        /* WHere did this come from??
        private ActionResult View(object p)
        {
            throw new NotImplementedException();
        }*/

        // GET: Shows/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "Name");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowID,NetworkID,Title,Genre,Rating,Photo,Website,Description")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Shows.Add(show);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "Name", show.NetworkID);
            return View(show);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "Name", show.NetworkID);
            return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowID,NetworkID,Title,Genre,Rating,Photo,Website,Description")] Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NetworkID = new SelectList(db.Networks, "NetworkID", "Name", show.NetworkID);
            return View(show);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = db.Shows.Find(id);
            db.Shows.Remove(show);
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
