using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursach.Model;

namespace Kursach.services
{
   public class TemaService
    {
        FirebaseClient client;
        public TemaService()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");

        }
        public async Task<List<Tema>> GetListTemaAsunc()
        {
            var tema = (await client.Child("Tema").OnceAsync<Tema>())
                .Select(c => new Tema
                {
                    TemaID = c.Object.TemaID,
                    NameTema = c.Object.NameTema

                }).ToList();
            return tema;

        }
    }
}
