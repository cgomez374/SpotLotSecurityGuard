using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace FIrebaseTest2
{
    public class FirebaseHelper
    {

        readonly FirebaseClient firebase = new FirebaseClient("https://securityguardspotlottest.firebaseio.com/");

        private readonly string ChildName = "Persons";
        public async Task<List<Person>> GetAllPersons()
        {
            return (await firebase
                .Child(ChildName)
                .OnceAsync<Person>()).Select(item => new Person
                {
                    Name = item.Object.Name,
                    PersonId = item.Object.PersonId,
                    LisencePlate = item.Object.LisencePlate
                }).ToList();
        }
        /*
        public async Task AddPerson(int personId, string name, long vinNum, string vehicle)
        {
            await firebase
                .Child(ChildName)
                .PostAsync(new Person() { PersonId=personId, Name = name, LisencePlate = vinNum, VehicleInformation = vehicle});
        }
        */

        public async Task<Person> GetPerson(string lisencePlate)
        {
            var allPersons = await GetAllPersons();
            await firebase
                .Child(ChildName)
                .OnceAsync<Person>();
            return allPersons.FirstOrDefault(a => a.LisencePlate == lisencePlate);
        }

        public async Task AddCitation(string vehInfo, string lisencePlate, int userId, string name, string reason)
        {

            await firebase
                .Child("Citations")
                .PostAsync(new Citation() { Name = name, 
                                            VehicleInfo = vehInfo,
                                            LisencePlate = lisencePlate, 
                                            UserId = userId, 
                                            ReasonForCitation = reason,
                                            CitationId = Global.counter++ });
        }



    }
}
