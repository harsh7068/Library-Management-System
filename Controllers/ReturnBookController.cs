using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library_Management_System.Controllers
{
    public class ReturnBookController : Controller
    {
        DB_LibraryEntities _db = new DB_LibraryEntities();
        // GET: ReturnBook
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getMid(int mid)
        {
            var memberID = (from s in _db.tblIssueBooks where s.memID == mid select new
            {
                DateIssued = s.issueDate,
                DateReturned = s.returnDate,
                memberIDD = s.memID,
                BookName = s.bookID,
                ElapsedDays = SqlFunctions.DateDiff("day", s.returnDate, DateTime.Now),
                ISBN = s.ISBN_Number,
            }).ToList();
            return Json(memberID, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(tblReturnBook _return)
        {
            if(ModelState.IsValid)
            {
                _db.tblReturnBooks.Add(_return);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_return);
        }
    }
}