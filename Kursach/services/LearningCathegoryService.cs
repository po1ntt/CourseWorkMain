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
    public class LearningCathegoryService
    {
        public class LearningCategoryService
        {
            FirebaseClient client;
            public LearningCategoryService()
            {
                client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
            }
            public async Task<List<LearnCategory>> GetCategoryLearningAsunc()
            {
                var lerningCategories = (await client.Child("LerningCategories").OnceAsync<LearnCategory>()).Select(f => new LearnCategory
                {
                    id_learncat = f.Object.id_learncat,
                    ImageLearnCat = f.Object.ImageLearnCat,
                    NameLernCategory = f.Object.NameLernCategory,
                    TemaID = f.Object.TemaID

                }).ToList();
                return lerningCategories;
            }
            public async Task<ObservableCollection<LearnCategory>> GetLearningCathegoryBuTema(int temaId)
            {
                var CathegoryBuTema = new ObservableCollection<LearnCategory>();
                var items = (await GetCategoryLearningAsunc()).Where(p => p.TemaID == temaId).ToList();
                foreach (var item in items)
                {
                    CathegoryBuTema.Add(item);
                }
                return CathegoryBuTema;
            }
        }
    }
}
