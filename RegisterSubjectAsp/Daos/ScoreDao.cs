using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterSubjectAsp.Daos
{
    public class ScoreDao
    {
        DBContext myDb = new DBContext();
        public Score getScore(int iduser,int idsub)
        {
            return myDb.scores.Where(p => p.id_user == iduser && p.id_subject == idsub ).FirstOrDefault();
        }
        public void add(Score score)
        {
            myDb.scores.Add(score);
            myDb.SaveChanges();
        }
        public void update(Score score)
        {
            var obj = myDb.scores.FirstOrDefault(x => x.id_score == score.id_score);
            obj.mark = score.mark;
            myDb.SaveChanges();
        }
        public List<Score> getAll(int iduser)
        {
            return myDb.scores.Where(p => p.id_user == iduser).ToList();
        }
    }
}