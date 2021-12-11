using RegisterSubjectAsp.Daos;
using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterSubjectAsp.Controllers
{
    public class AuthenticationController : Controller
    {
        UserDao userDao = new UserDao();
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User checkLogin  = userDao.checkLogin(user.username, user.password);

            if(checkLogin != null)
            {

                Session.Add("User",checkLogin);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msg = "Username or password incorrect";
                return View();
            }

        }
    }
}