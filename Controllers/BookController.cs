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
    public class BookController : Controller
    {
        private DB_LibraryEntities db = new DB_LibraryEntities();

        // GET: Book
        public ActionResult Index()
        {
            var tblBooks = db.tblBooks.Include(t => t.tblAuthor).Include(t => t.tblCategory).Include(t => t.tblPublisher);
            return View(tblBooks.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBook tblBook = db.tblBooks.Find(id);
            if (tblBook == null)
            {
                return HttpNotFound();
            }
            return View(tblBook);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.authID = new SelectList(db.tblAuthors, "authID", "authName");
            ViewBag.catID = new SelectList(db.tblCategories, "catID", "catName");
            ViewBag.pubId = new SelectList(db.tblPublishers, "pubId", "pubName");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bookID,bookName,catID,authID,pubId,bookContents,bookPages,ISBN_Number,bookEdition")] tblBook tblBook)
        {
            if (ModelState.IsValid)
            {
                db.tblBooks.Add(tblBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.authID = new SelectList(db.tblAuthors, "authID", "authName", tblBook.authID);
            ViewBag.catID = new SelectList(db.tblCategories, "catID", "catName", tblBook.catID);
            ViewBag.pubId = new SelectList(db.tblPublishers, "pubId", "pubName", tblBook.pubId);
            return View(tblBook);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBook tblBook = db.tblBooks.Find(id);
            if (tblBook == null)
            {
                return HttpNotFound();
            }
            ViewBag.authID = new SelectList(db.tblAuthors, "authID", "authName", tblBook.authID);
            ViewBag.catID = new SelectList(db.tblCategories, "catID", "catName", tblBook.catID);
            ViewBag.pubId = new SelectList(db.tblPublishers, "pubId", "pubName", tblBook.pubId);
            return View(tblBook);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bookID,bookName,catID,authID,pubId,bookContents,bookPages,ISBN_Number,bookEdition")] tblBook tblBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.authID = new SelectList(db.tblAuthors, "authID", "authName", tblBook.authID);
            ViewBag.catID = new SelectList(db.tblCategories, "catID", "catName", tblBook.catID);
            ViewBag.pubId = new SelectList(db.tblPublishers, "pubId", "pubName", tblBook.pubId);
            return View(tblBook);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBook tblBook = db.tblBooks.Find(id);
            if (tblBook == null)
            {
                return HttpNotFound();
            }
            return View(tblBook);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblBook tblBook = db.tblBooks.Find(id);
            db.tblBooks.Remove(tblBook);
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
