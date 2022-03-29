using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using Kursach.Model;

namespace Kursach.services
{
    class UserService
    {
        public class UserServices
        {
            FirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://victorinaproject-default-rtdb.firebaseio.com/"
            };
            FirebaseClient client;
            public UserServices()
            {
                client = new FirebaseClient(config);
            }
            public async Task<bool> IsUserExists(string login)
            {
                bool Exists = false;
                var users = await client.GetAsync("Users");
                List<Users> p = users.ResultAs<List<Users>>();
                foreach(var item in p)
                {
                    
                    if(item.Login == login)
                    {
                        Exists = true;
                        break;
                    }
                    
                }
                return Exists;
            
               
            }
            public async Task<bool> RegisterUser(string login, string password, string email)
            {
                if (await IsUserExists(login) == false)
                {
                    await client.Child("Users").PostAsync(new UserModel()
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
                var user = (await client.Child("Users").OnceAsync<UserModel>()).Where(u => u.Object.Login == login)
                    .Where(u => u.Object.Password == password).FirstOrDefault();
                return (user != null);
            }
            public async Task<List<UserModel>> SelectUsers()
            {
                var users = (await client.Child("Users").OnceAsync<UserModel>())
                    .Select(c => new UserModel
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
