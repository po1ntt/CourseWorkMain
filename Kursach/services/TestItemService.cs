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
    public class TestItemServices
    {
        FirebaseClient client;
        public TestItemServices()
        {
            client = new FirebaseClient("https://victorinaproject-default-rtdb.firebaseio.com/");
        }
        public async Task<List<Tests>> GetTestsModelsAsync()
        {
            var tests = (await client.Child("Tests").OnceAsync<Tests>()).Select(f => new Tests
            {
                CategoryId = f.Object.CategoryId,
                Description = f.Object.Description,
                Name = f.Object.Name,
                TestId = f.Object.TestId




            }).ToList();
            return tests;
        }
        public async Task<ObservableCollection<Tests>> GetTestByCathegoryAsync(int categoryID)
        {
            var TestItemsByCathegory = new ObservableCollection<Tests>();
            var items = (await GetTestsModelsAsync()).Where(p => p.CategoryId == categoryID).ToList();
            foreach (var item in items)
            {
                TestItemsByCathegory.Add(item);
            }
            return TestItemsByCathegory;
        }
        public async Task<ObservableCollection<Tests>> GetLatestTestsAsunc()

        {
            var latestTestItems = new ObservableCollection<Tests>();
            var items = (await GetTestsModelsAsync()).OrderByDescending(f => f.TestId).Take(3);
            foreach (var item in items)
            {
                latestTestItems.Add(item);
            }
            return latestTestItems;

        }
        public async Task<Results> GetResultsTestByUserLogin(string user_login, string nametest, int cathegoryid)
        {
            var result = (await client.Child("Results").OnceAsync<Results>()).Select(f => new Results
            {
                Scoreprecennt = f.Object.Scoreprecennt
            }).FirstOrDefault(p => p.User_login == user_login && p.NameTestDone == nametest && p.CathegoryId == cathegoryid);
            return result;
        }
        public async Task<Tests> GetTestById(int TestId)
        {
            var test = (await GetTestsModelsAsync()).Where(p => p.TestId == TestId).FirstOrDefault() as Tests;
            return test;
        }

    }
}
