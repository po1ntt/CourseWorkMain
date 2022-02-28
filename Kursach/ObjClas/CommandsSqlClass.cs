using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursach.Model;
using Kursach.Pages;

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
        public static string Create_user(string name, string surname, string birtday, string email, string password, string login, int newid_role, string newphone)
        {
            string result = "ошибка";
            using(VictrovinaEntities context = new VictrovinaEntities())
            {
                context.Users.Add(new Users
                {
                    name = name,
                    surname = surname,
                    birthday = DateTime.Parse(birtday),
                    mail = email,
                    password = password,
                    login = login,
                    id_role = newid_role,
                    phone = newphone
                }); 
                context.SaveChanges();
                result = $"Новый пользователь с логином " + login + " добавлен!";
                return result;
            }
                
        }
        public static string authorization(string login, string password)
        {
            string result = "Пользователь не найден";
            using( VictrovinaEntities context = new VictrovinaEntities())
            {
               var user = context.Users.FirstOrDefault(p => p.login == login && p.password == password);
               if(user != null)
                {
                    result = "Авторизация прошла успешно!";
                    if (user.id_role == 1)
                        ObjClas.Frame.FrameOBJ.Navigate(new UserInterface());
                    if (user.id_role == 2)
                        ObjClas.Frame.FrameOBJ.Navigate(new KuratorInteface());
                    if (user.id_role == 3)
                        ObjClas.Frame.FrameOBJ.Navigate(new AdminInterface());
                    return result;
                }
                else
                {
                    return result;
                }

            }
        }
        public static string EditUserInfo(Users olduser, string newname,string newsurname, string birthday,string newphone, string newemail, int userrole)
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
                    user.birthday = DateTime.Parse(birthday);
                    user.id_role = userrole;
                    context.SaveChanges();
                    result = "данные пользователя с логином " + user.login + " обновлены";
                }
            }
            return result;
        }
        // получение роли пользователя по id роли
        public static Role GetRolebyId(int id)
        {
            using (VictrovinaEntities context = new VictrovinaEntities())
            {
                Role role = context.Role.FirstOrDefault(p => p.id_r == id);
                return role;
            }
        }

        public static List<Role> GetRoles()
        {
            using(VictrovinaEntities context = new VictrovinaEntities())
            {
                var result = context.Role.ToList();
                return result;
            }
        }
    }
}
