using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library_Management_System.Models;

namespace Library_Management_System.Controllers
{
    public class PublisherController : Controller
    {
        private DB_LibraryEntities db = new DB_LibraryEntities();

        // GET: Publisher
        public ActionResult Index()
        {
            return View(db.tblPublishers.ToList());
        }

        // GET: Publisher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPublisher tblPublisher = db.tblPublishers.Find(id);
            if (tblPublisher == null)
            {
                return HttpNotFound();
            }
            return View(tblPublisher);
        }

        // GET: Publisher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publisher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pubId,pubName,pubAddress,pubPhone")] tblPublisher tblPublisher)
        {
            if (ModelState.IsValid)
            {
                db.tblPublishers.Add(tblPublisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblPublisher);
        }

        // GET: Publisher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPublisher tblPublisher = db.tblPublishers.Find(id);
            if (tblPublisher == null)
            {
                return HttpNotFound();
            }
            return View(tblPublisher);
        }

        // POST: Publisher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pubId,pubName,pubAddress,pubPhone")] tblPublisher tblPublisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPublisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblPublisher);
        }

        // GET: Publisher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPublisher tblPublisher = db.tblPublishers.Find(id);
            if (tblPublisher == null)
            {
                return HttpNotFound();
            }
            return View(tblPublisher);
        }

        // POST: Publisher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPublisher tblPublisher = db.tblPublishers.Find(id);
            db.tblPublishers.Remove(tblPublisher);
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
