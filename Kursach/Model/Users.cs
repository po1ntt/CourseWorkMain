using Kursach.services;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.Model
{
   public class Users
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string  Password { get; set; }
        public string Email { get; set; }
        public DateTime BirtDay { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
        [NotMapped]
        public Role UserRole { get; set; }
       
        
        public async void getrole()
        {
            UserService user = new UserService();
            UserRole = await user.GetInfoAboutUser(RoleId);
           
        }
        public Users()
        {
            getrole();
        }
    }
}
