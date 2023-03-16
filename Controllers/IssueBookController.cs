using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class IssueBookController : Controller
    {
        DB_LibraryEntities _db = new DB_LibraryEntities();
        // GET: IssueBook
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetMid(int mid)
        {
            var memberid = (from s in _db.tblMembers where s.memID == mid select s.memName).ToList();

            return Json(memberid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetISBN(string name)
        {
            var ISBN_Num = (from s in _db.tblBooks where s.bookName == name select s.ISBN_Number).ToList();
            return Json(ISBN_Num, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetBook()
        {
            var books = _db.tblBooks.Select(p => new
            {
                bokID = p.bookID,
                bokName = p.bookName,
            }
            ).ToList();
            return Json(books, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(tblIssueBook _issue)
        {
            if (ModelState.IsValid)
            {
                _db.tblIssueBooks.Add(_issue);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_issue);
        }
    }
}