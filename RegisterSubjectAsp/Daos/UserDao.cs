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

        public List<User> getListStudent()
        {
            return myDb.users.Where(x => x.Role.id_role == 3).ToList();
        }

        public List<User> getListGiangVien()
        {
            return myDb.users.Where(x => x.Role.id_role == 2).ToList();
        }

        public void add(User user)
        {
            myDb.users.Add(user);
            myDb.SaveChanges();
        }

        public void edit(User user)
        {
            var obj = myDb.users.FirstOrDefault(x => x.id_user == user.id_user);
            obj.username = user.username;
            obj.password = user.password;
            obj.email = user.email;
            obj.gender = user.gender;
            obj.address = user.address;
            obj.fullname = user.fullname;
            obj.phoneNumber = user.phoneNumber;
            obj.birthday = user.birthday;
            myDb.SaveChanges();
        }

        public void delete(int id)
        {
            var obj = myDb.users.FirstOrDefault(x => x.id_user == id);
            myDb.users.Remove(obj);
            myDb.SaveChanges();
        }

        public User checkExistName(string name)
        {
            return myDb.users.FirstOrDefault(x => x.username == name);
        }

        public User getUserById(int id)
        {
            return myDb.users.FirstOrDefault(x => x.id_user == id);
        }
    }
}