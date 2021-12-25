using RegisterSubjectAsp.Daos;
using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterSubjectAsp.Controllers
{
    public class ScheduleController : Controller
    {
        ScheduleDao scheduleDao = new ScheduleDao();
        SubjectDao subjectDao = new SubjectDao();
        UserDao userDao = new UserDao();
        GradeDao gradeDao = new GradeDao();
        // GET: Schedule
        public ActionResult Index(string msg)
        {
            ViewBag.List = scheduleDao.getAll();
            ViewBag.Sub = subjectDao.getAll();
            ViewBag.User = userDao.getListGiangVien();
            ViewBag.Grade = gradeDao.getAll();
            ViewBag.Msg = msg;
            return View();
        }
        public ActionResult Add(FormCollection form)
        {
            Schedule schedule = new Schedule();
            schedule.id_user = Int32.Parse(form["iduser"]);
            schedule.id_subject = Int32.Parse(form["idsub"]);
            schedule.id_grade = Int32.Parse(form["idgrade"]);
            DateTime open = DateTime.Parse(form["open"]);
            DateTime close = DateTime.Parse(form["close"]);
            schedule.open_day = open;
            schedule.close_day = close;
            schedule.status = 0;
            scheduleDao.add(schedule);
            return RedirectToAction("Index", new { msg = "1" });
        }
        public ActionResult ChangeStatus(FormCollection form)
        {
            Schedule schedule = new Schedule();
            schedule.id_schedule = Int32.Parse(form["idschedule"]);
            schedule.status = 1;
            scheduleDao.changeStatus(schedule);
            return RedirectToAction("Index", new { msg = "1" });
        }
        public ActionResult AddSchedule(FormCollection form)
        {
            ScheduleStudent scheduleStudent = new ScheduleStudent();
            scheduleStudent.id_user = Int32.Parse(form["iduser"]);
            scheduleStudent.id_schedule = Int32.Parse(form["idsche"]);
            scheduleDao.addSchedule(scheduleStudent);
            return RedirectToAction("Index", new { msg = "1" });
        }
    }
}