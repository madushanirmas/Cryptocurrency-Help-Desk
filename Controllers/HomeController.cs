using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bitcoin.Controllers
{
    
    public class HomeController : Controller
    {
       

        public ActionResult Login()
        {
            ViewBag.Title = "Login Page";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Title = "Register Page";

            return View();
        }

        public ActionResult BlogPost()
        {
            ViewBag.Title = "Blog Post";
            Session["type"] = "User";
            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Title = "Up Coming Events";

            return View();
        }

        public ActionResult Profile()
        {
            ViewBag.Title = "My Profile";

            return View();
        }

        public ActionResult Payment()
        {
            ViewBag.Title = "Payment";

            return View();
        }
    }
}
