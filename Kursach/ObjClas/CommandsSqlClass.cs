using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.ObjClas
{
    class CommandsSqlClass
    {
        
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


    }
}
