using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Library_Management_System.Controllers
{
    public class LoginController : Controller
    {
        DB_LibraryEntities db = new DB_LibraryEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblUser _usr)
        {
            var data = (from a in db.tblUsers where a.email == _usr.email && a.pwd == _usr.pwd select a).ToList();
            if(data.Count > 0)
            {
                
                    if (data[0].role == "1")
                    {
                        Session["Role"] = data[0].role;
                        Session["ID"] = data[0].id;
                        Session["name"] = data[0].name;
                        return RedirectToAction("AdminPanel", "Home1");
                    }
                    else
                    {
                        Session["ID"] = data[0].id;
                        Session["name"] = data[0].name;
                        return RedirectToAction("Index", "Home");
                    }
                }
            
            else
            {
                ViewBag.msg = "Login failed, please check your Email ID and password!!!";
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}