using RegisterSubjectAsp.Daos;
using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterSubjectAsp.Controllers
{
    public class CourseController : Controller
    {
        CourseDao courseDao = new CourseDao();
        SubjectDao subjectDao = new SubjectDao();
        // GET: Subject
        public ActionResult Index(string msg)
        {
            ViewBag.List = courseDao.getAll();
            ViewBag.Sub = subjectDao.getAll();
            ViewBag.Msg = msg;
            return View();
        }

        public ActionResult Delete(FormCollection form)
        {
            var id = Int32.Parse(form["id"]);
            courseDao.delete(id);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Add(FormCollection form)
        {
            Course course = new Course();
            course.faculty = form["name"];
            course.id_subject = Int32.Parse(form["idsub"]);
            var obj = courseDao.getCoursetByName(form["name"]);
            if (obj == null)
            {
                courseDao.add(course);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }

        public ActionResult Update(FormCollection form)
        {
            Course course = new Course();
            course.faculty = form["name"];
            course.id_subject = Int32.Parse(form["idsub"]);
            course.id_course = Int32.Parse(form["id"]);
            var obj = courseDao.getCoursetByName(form["name"]);
            if (obj == null)
            {
                courseDao.update(course);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                var objNew = courseDao.getCoursetByName(form["name"]);
                if (objNew.faculty.Equals(form["name"]))
                {
                    courseDao.update(course);
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