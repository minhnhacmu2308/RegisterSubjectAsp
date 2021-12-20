using RegisterSubjectAsp.Daos;
using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterSubjectAsp.Controllers
{
    public class GradeController : Controller
    {
        GradeDao gradeDao = new GradeDao();
        // GET: Subject
        public ActionResult Index(string msg)
        {
            ViewBag.List = gradeDao.getAll();
            ViewBag.Msg = msg;
            return View();
        }

        public ActionResult Delete(FormCollection form)
        {
            var id = Int32.Parse(form["id"]);
            gradeDao.delete(id);
            return RedirectToAction("Index", new { msg = "1" });
        }

        public ActionResult Add(FormCollection form)
        {
            Grade grade = new Grade();
            grade.name = form["name"];
            var obj = gradeDao.getGradetByName(form["name"]);
            if (obj == null)
            {
                gradeDao.add(grade);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                return RedirectToAction("Index", new { msg = "2" });
            }
        }

        public ActionResult Update(FormCollection form)
        {
            Grade grade = new Grade();
            grade.name = form["name"];
            grade.id_grade = Int32.Parse(form["id"]);
            var obj = gradeDao.getGradetByName(form["name"]);
            if (obj == null)
            {
                gradeDao.update(grade);
                return RedirectToAction("Index", new { msg = "1" });
            }
            else
            {
                var objNew = gradeDao.getGradetByName(form["name"]);
                if (objNew.name.Equals(form["name"]))
                {
                    gradeDao.update(grade);
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