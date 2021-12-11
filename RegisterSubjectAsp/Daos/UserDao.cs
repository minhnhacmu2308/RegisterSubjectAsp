using RegisterSubjectAsp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegisterSubjectAsp.Daos
{
    public class UserDao
    {
        DBContext myDb = new DBContext();

        public User checkLogin(string username, string password)
        {
            return myDb.users.FirstOrDefault(x =>x.username == username && x.password == password);
        }
    }
}