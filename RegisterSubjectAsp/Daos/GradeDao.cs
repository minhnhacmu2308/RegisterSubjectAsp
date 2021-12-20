using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterSubjectAsp.Daos
{
    public class GradeDao
    {
        DBContext myDb = new DBContext();

        public List<Grade> getAll()
        {
            return myDb.grades.ToList();
        }

        public Grade getGradetByName(string name)
        {
            return myDb.grades.FirstOrDefault(x => x.name == name);
        }

        public void add(Grade grade)
        {
            myDb.grades.Add(grade);
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.grades.FirstOrDefault(x => x.id_grade == id);
            myDb.grades.Remove(obj);
            myDb.SaveChanges();
        }

        public void update(Grade grade)
        {
            var obj = myDb.grades.FirstOrDefault(x => x.id_grade == grade.id_grade);
            obj.name = grade.name;
            myDb.SaveChanges();
        }
    }
}