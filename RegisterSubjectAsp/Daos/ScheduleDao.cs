using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterSubjectAsp.Daos
{
    public class ScheduleDao
    {
        DBContext myDb = new DBContext();

        public List<Schedule> getAll()
        {
            return myDb.schedules.ToList();
        }
        public List<Schedule> listGrade(int idgv)
        {
            return myDb.schedules.Where(p => p.id_user == idgv).ToList();
        }
        public Schedule getSchedule(int idsche)
        {
            return myDb.schedules.Where(p => p.id_schedule == idsche).FirstOrDefault();
        }
        public void add(Schedule schedule)
        {
            myDb.schedules.Add(schedule);
            myDb.SaveChanges();
        }
        public void addSchedule(ScheduleStudent scheduleStudent)
        {
            string sql = "INSERT INTO ScheduleStudents(id_schedule,id_user) VALUES('" + scheduleStudent.id_schedule + "','" + scheduleStudent.id_user + "') ";
            myDb.Database.ExecuteSqlCommand(sql);
        }
        public void delete(int id)
        {
            var obj = myDb.schedules.FirstOrDefault(x => x.id_schedule == id);
            myDb.schedules.Remove(obj);
            myDb.SaveChanges();
        }

        public void update(Schedule schedule)
        {
            var obj = myDb.schedules.FirstOrDefault(x => x.id_schedule == schedule.id_schedule);
            obj.id_subject = schedule.id_subject;
            obj.id_user = schedule.id_user;
            obj.id_grade = schedule.id_grade;
            obj.open_day = schedule.open_day;
            obj.close_day = schedule.close_day;
            myDb.SaveChanges();
        }
        public List<ScheduleStudent> getDetail(int idsche)
        {
            return myDb.scheduleStudents.Where(p => p.id_schedule == idsche).ToList();
        }
        public List<ScheduleStudent> listScheStu(int iduser)
        {
            return myDb.scheduleStudents.Where(p => p.id_user == iduser).ToList();
        }
        public bool checkRegister(int idsche,int iduser)
        {
            var result = myDb.scheduleStudents.Where(p => p.id_schedule == idsche && p.id_user == iduser).FirstOrDefault();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}