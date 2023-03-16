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
    public class AuthorController : Controller
    {
        private DB_LibraryEntities db = new DB_LibraryEntities();

        // GET: Author
        public ActionResult Index()
        {
            return View(db.tblAuthors.ToList());
        }

        // GET: Author/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAuthor tblAuthor = db.tblAuthors.Find(id);
            if (tblAuthor == null)
            {
                return HttpNotFound();
            }
            return View(tblAuthor);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "authID,authName,authAddress,authPhone")] tblAuthor tblAuthor)
        {
            if (ModelState.IsValid)
            {
                db.tblAuthors.Add(tblAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAuthor);
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAuthor tblAuthor = db.tblAuthors.Find(id);
            if (tblAuthor == null)
            {
                return HttpNotFound();
            }
            return View(tblAuthor);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "authID,authName,authAddress,authPhone")] tblAuthor tblAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAuthor);
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAuthor tblAuthor = db.tblAuthors.Find(id);
            if (tblAuthor == null)
            {
                return HttpNotFound();
            }
            return View(tblAuthor);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAuthor tblAuthor = db.tblAuthors.Find(id);
            db.tblAuthors.Remove(tblAuthor);
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
