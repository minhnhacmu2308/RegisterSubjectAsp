using RegisterSubjectAsp.Daos;
using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterSubjectAsp.Controllers
{
    public class UserController : Controller
    {
        UserDao userDao = new UserDao();
        ScoreDao scoreDao = new ScoreDao();
        ScheduleDao scheduleDao = new ScheduleDao();
        // GET: Subject
        public ActionResult Index(string msg)
        {
            ViewBag.List = userDao.getListStudent();
            ViewBag.Msg = msg;
            return View();
        }
        public ActionResult ListSchedule()
        {
            var user = (User)Session["USER"];
            ViewBag.List = scheduleDao.listScheStu(user.id_user);
            return View();
        }
        public ActionResult ListScore()
        {
            var user = (User)Session["USER"];
            ViewBag.List = scoreDao.getAll(user.id_user);
            return View();
        }
        public ActionResult Infor()
        {
            var userInfomatiom = (User)Session["USER"];
            ViewBag.Profile = userDao.getUserById(userInfomatiom.id_user);
            return View();
        }

        public ActionResult ListGiangVien(string msg)
        {
            ViewBag.List = userDao.getListGiangVien();
            ViewBag.Msg = msg;
            return View();
        }

        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            var id = form["id"];
            userDao.delete(Int32.Parse(id));
            return RedirectToAction("Index", new { msg = "1" });
        }
        [HttpPost]
        public ActionResult DeleteGv(FormCollection form)
        {
            var id = form["id"];
            userDao.delete(Int32.Parse(id));
            return RedirectToAction("ListGiangVien", new { msg = "1" });
        }
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            User principal = new User();
            principal.fullname = form["fullname"];
            principal.username = form["username"];
            principal.password = form["password"];
            principal.id_role = 3;
            principal.gender = Int32.Parse(form["gender"]);
            principal.address = form["address"];
            principal.email = form["email"];
            principal.phoneNumber = form["phoneNumber"];
            principal.birthday = form["birthday"];
            principal.status = 1;
            var obj = userDao.checkExistName(form["username"]);
            if (obj == null)
            {
                userDao.add(principal);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }

        }

        [HttpPost]
        public ActionResult AddGiangVien(FormCollection form)
        {
            User principal = new User();
            principal.fullname = form["fullname"];
            principal.username = form["username"];
            principal.password = form["password"];
            principal.id_role = 2;
            principal.gender = Int32.Parse(form["gender"]);
            principal.address = form["address"];
            principal.email = form["email"];
            principal.phoneNumber = form["phoneNumber"];
            principal.birthday = form["birthday"];
            principal.status = 1;
            var obj = userDao.checkExistName(form["username"]);
            if (obj == null)
            {
                userDao.add(principal);
                return RedirectToAction("ListGiangVien", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("ListGiangVien", new { msg = "2" });
            }

        }


        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            User principal = new User();
            principal.id_user = Int32.Parse(form["id"]);
            principal.fullname = form["fullname"];
            principal.username = form["username"];
            principal.password = form["password"];
            principal.gender = Int32.Parse(form["gender"]);
            principal.address = form["address"];
            principal.email = form["email"];
            principal.phoneNumber = form["phoneNumber"];
            principal.birthday = form["birthday"];
            userDao.edit(principal);
            return RedirectToAction("Index", new { msg = "1" });
        }

        [HttpPost]
        public ActionResult UpdateGiangVien(FormCollection form)
        {
            User principal = new User();
            principal.id_user = Int32.Parse(form["id"]);
            principal.fullname = form["fullname"];
            principal.username = form["username"];
            principal.password = form["password"];
            principal.gender = Int32.Parse(form["gender"]);
            principal.address = form["address"];
            principal.email = form["email"];
            principal.phoneNumber = form["phoneNumber"];
            principal.birthday = form["birthday"];
            userDao.edit(principal);
            return RedirectToAction("ListGiangVien", new { msg = "1" });
        }
    }
}