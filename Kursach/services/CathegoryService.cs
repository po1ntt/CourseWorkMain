using Firebase.Database;
using Kursach.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach.services
{
    public class СathegoryServices
    {
        FirebaseClient client;
        public СathegoryServices()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");

        }
        public async Task<List<Category>> GetCathegoryAsync()
        {
            var categories = (await client.Child("Cathegories").OnceAsync<Category>())
                .Select(c => new Category
                {
                    CathegoryId = c.Object.CathegoryId,
                    CathegoryName = c.Object.CathegoryName,
                    ImageUrl = c.Object.ImageUrl,
                    TemaID = c.Object.TemaID


                }).ToList();
            return categories;

        }

        public async Task<ObservableCollection<Category>> GetCathegoryBuTema(int temaId)
        {
            var CathegoryBuTema = new ObservableCollection<Category>();
            var items = (await GetCathegoryAsync()).Where(p => p.TemaID == temaId).ToList();
            foreach (var item in items)
            {
                CathegoryBuTema.Add(item);
            }
            return CathegoryBuTema;
        }
    }
}
