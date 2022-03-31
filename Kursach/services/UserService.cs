using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kursach.Model;

using System;
using Firebase.Database;
using Firebase.Database.Query;
using System.Reactive.Linq;
using System.Collections.ObjectModel;

namespace Kursach.services
{
  
        public class UserService
        {
            FirebaseClient client;
            public UserService()
            {
                client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
            }
            public async Task<bool> IsUserExists(string login)
            {
                var user = (await client.Child("Users").OnceAsync<Users>()).Where(u => u.Object.Login == login).FirstOrDefault();
                return (user != null);
            }
        public async Task<ObservableCollection<Users>> GetUserByLogin(string userlogin)
        {
            var UserBylogin = new ObservableCollection<Users>();
            var items = (await SelectUsers()).Where(p => p.Login == userlogin).ToList();
            foreach (var item in items)
            {
                UserBylogin.Add(item);
            }
            return UserBylogin;
        }
        public async Task<bool> RegisterUser(string login, string password, string email, string birthday, string name, string surname, int phone)
            {
                if (await IsUserExists(login) == false)
                {
                    await client.Child("Users").PostAsync(new Users()
                    {
                        Login = login,
                        Password = password,
                        Email = email,
                        SurName = surname,
                        Name = name,
                        BirtDay = Convert.ToDateTime(birthday),
                        Phone = phone,
                        RoleId = 1
                        
                       
                    });
                    return true;

                }
                else
                {
                    return false;
                }
            }
            public async Task<bool> LoginUser(string login, string password)
            {
                var user = (await client.Child("Users").OnceAsync<Users>()).Where(u => u.Object.Login == login && u.Object.Password == password)
                    .FirstOrDefault();
                return (user != null);
            }
        public async Task<List<Role>> Roles()
        {
            List<Role> roles = (await client.Child("Role").OnceAsync<Role>()).Select(c => new Role
            {
                id_role = c.Object.id_role,
                NameRole = c.Object.NameRole
            }).ToList();
            return roles;
        }
        public async Task<Role> GetInfoAboutUser(int id_r)
        {
            var role = (await Roles()).Where(p => id_r == p.id_role).FirstOrDefault();
            return role;
        }
            public async Task<List<Users>> SelectUsers()
            {
                var users = (await client.Child("Users").OnceAsync<Users>())
                    .Select(c => new Users
                    {
                        Login = c.Object.Login,
                        SurName = c.Object.SurName,
                        BirtDay = c.Object.BirtDay,
                        Password = c.Object.Password,
                        Name = c.Object.Name,
                        Phone = c.Object.Phone,
                        Email = c.Object.Email,
                        RoleId = c.Object.RoleId,
                        UserRole = c.Object.UserRole


                    }).ToList();
                return users;

            }
        public async Task<bool> UpdateUser(string name, int role_id, string login, string birthday, string surname, int phone, string email,string password)
        {
            var toUpdateUser = (await client.Child("Users")
                .OnceAsync<Users>())
                .FirstOrDefault
                (a=> a.Object.Login == login);
           
                Users s = new Users() {Name  = name, Login = login, RoleId = role_id, SurName = surname, Email = email, BirtDay = Convert.ToDateTime(birthday),Password = password, Phone = phone };
                await client.Child("Users")
                    .Child(toUpdateUser.Key)
                    .PutAsync(s);

            return true;
        }


    }
    } 