using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterSubjectAsp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string result = (string)Session["User"];
            if (string.IsNullOrEmpty(result))
            {
                return RedirectToAction("Login", "Authentication");
            }
            else
            {
                return View();
            }
               
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}