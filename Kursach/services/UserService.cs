using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kursach.Model;

using System;
using Firebase.Database;

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
            public async Task<bool> RegisterUser(string login, string password, string email)
            {
                if (await IsUserExists(login) == false)
                {
                    await client.Child("Users").PostAsync(new Users()
                    {
                        Login = login,
                        Password = password,
                        Email = email
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
                var user = (await client.Child("Users").OnceAsync<Users>()).Where(u => u.Object.Login == login)
                    .Where(u => u.Object.Password == password).FirstOrDefault();
                return (user != null);
            }
            public async Task<List<Users>> SelectUsers()
            {
                var users = (await client.Child("Users").OnceAsync<Users>())
                    .Select(c => new Users
                    {
                        Login = c.Object.Login,
                        SurName = c.Object.SurName,
                        BirtDay = c.Object.BirtDay,
                        Password = c.Object.Password


                    }).ToList();
                return users;

            }


        }
    } 