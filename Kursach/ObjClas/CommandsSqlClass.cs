using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursach.Model;

namespace Kursach.ObjClas
{
    class CommandsSqlClass
    {
        public static List<Users> getallusers()
        {
            using(VictrovinaEntities context = new VictrovinaEntities())
            {
                var result = context.Users.ToList();
                return result;
            }
        }
        public static Users GetUsersBylogin(string log)
        {
            VictrovinaEntities context = new VictrovinaEntities();
            return context.Users.Where(x => x.login == log).FirstOrDefault();
        }
        public static Users GetUsersWithoutAdmins(string log)
        {
            VictrovinaEntities context = new VictrovinaEntities();
            return context.Users.Where(x => x.id_role != 3).FirstOrDefault();
        }
        public static string DeleteUser(Users user)
        {
            string result = "Такого пользователя не существует";
            using (VictrovinaEntities context = new VictrovinaEntities())
            {
                context.Users.Remove(user);
                context.SaveChanges();
                result = "Аккаунт удален " + user.login + " удален";
            };

            return result;
        }
        public static string EditRole(Users olduser, int newrole)
        {
            string result = "Пользователь уже имеет эту роль";
            using(VictrovinaEntities context = new VictrovinaEntities())
            {
                Users user = context.Users.FirstOrDefault(x => x.login == olduser.login);
                if (user != null)
                {
                    user.id_role = newrole;
                    context.SaveChanges();
                    result = "Роль изменена у пользователя c логином  " + user.login;
                }
            }
            return result;
        }
        public static string EditUserInfo(Users olduser, string newname,string newsurname,string newbirthday,string newphone, string newemail)
        {
            string result = "информация не измена";
            using(VictrovinaEntities context = new VictrovinaEntities())
            {
                Users user = context.Users.FirstOrDefault(p => p.login == olduser.login);
                if(user!=null)
                {
                    user.name = newname;
                    user.surname = newsurname;
                    user.mail = newemail;
                    user.phone = newphone;
                    user.birthday = DateTime.Parse(newbirthday);
                    context.SaveChanges();
                    result = "данные пользователя с логином " + user.login + " обновлены";
                }
            }
            return result;
        }
        

    }
}
