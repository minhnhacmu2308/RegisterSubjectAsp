using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterSubjectAsp.Daos
{
    public class CourseDao
    {
        DBContext myDb = new DBContext();

        public List<Course> getAll()
        {
            return myDb.courses.ToList();
        }

        public Course getCoursetByName(string name)
        {
            return myDb.courses.FirstOrDefault(x => x.faculty == name);
        }

        public void add(Course course)
        {
            myDb.courses.Add(course);
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.courses.FirstOrDefault(x => x.id_course == id);
            myDb.courses.Remove(obj);
            myDb.SaveChanges();
        }

        public void update(Course course)
        {
            var obj = myDb.courses.FirstOrDefault(x => x.id_course == course.id_course);
            obj.faculty = course.faculty;
            obj.id_subject = course.id_subject;
            myDb.SaveChanges();
        }
    }
}