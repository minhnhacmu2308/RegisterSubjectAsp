using RegisterSubjectAsp.Daos;
using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterSubjectAsp.Controllers
{
    public class SubjectController : Controller
    {
        SubjectDao subjectDao = new SubjectDao();
        // GET: Subject
        public ActionResult Index(string msg)
        {
            ViewBag.List = subjectDao.getAll();
            ViewBag.Msg = msg;
            return View();
        }

        public ActionResult Delete(FormCollection form)
        {
            var id = Int32.Parse(form["id"]);
            subjectDao.delete(id);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Add(FormCollection form)
        {
            Subject subject = new Subject();
            subject.name = form["name"];
            subject.code = form["code"];
            subject.credit = form["credit"];
            DateTime startday = DateTime.Parse(form["start"]);
            DateTime endday = DateTime.Parse(form["end"]);
            subject.start_day = startday;
            subject.end_day = endday;
            subject.status = 1;
            var obj = subjectDao.getSubjectByName(form["name"]);
            if (obj == null)
            {
                subjectDao.add(subject);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }

        public ActionResult Update(FormCollection form)
        {
            Subject subject = new Subject();
            subject.name = form["name"];
            subject.code = form["code"];
            subject.credit = form["credit"];
            DateTime startday = DateTime.Parse(form["start"]);
            DateTime endday = DateTime.Parse(form["end"]);
            subject.start_day = startday;
            subject.end_day = endday;
            subject.id_subject = Int32.Parse(form["id"]);
            var obj = subjectDao.getSubjectByName(form["name"]);
            if (obj == null)
            {
                subjectDao.update(subject);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                var objNew = subjectDao.getSubjectByName(form["name"]);
                if (objNew.name.Equals(form["name"]))
                {
                    subjectDao.update(subject);
                    return RedirectToAction("Index", new { msg = "1" });
                }
                else
                {
                    return RedirectToAction("Index", new { msg = "2" });
                }

            }
        }
    }
}