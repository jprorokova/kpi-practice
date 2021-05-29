using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hospital.Data;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using Hospital.Onion;

namespace Hospital.Tests
{
    [TestFixture]
    public class BankIntegrationTests
    {
        private HttpClient _patient;
        private CustomWebApplicationFactory _factory;
        private const string RequestUrl = "api/Hospitals/";

        [SetUp]
        public void SetUp()
        {
            _factory = new CustomWebApplicationFactory();
            _patient = _factory.CreateClient();
        }
        [Test]
        public async Task hospitalsController_GetById_ReturnshospitalModel()
        {
            var httpResponse = await _patient.GetAsync(RequestUrl + 1);
            
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var hospital = JsonConvert.DeserializeObject<Orchestrators.Hospitals.Hospital>(stringResponse);

            Assert.AreEqual(1, hospital.Id);
            Assert.AreEqual(12313, hospital.Count);
            Assert.AreEqual("190", hospital.Address);
        }
        [Test]
        public async Task HospitalsController_Add_AddsHospitalToDatabase()
        {
            var bank = new Orchestrators.Hospitals.Hospital(){Id= 5, Address = "rttt", Count = 13};
            var content = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");
            var httpResponse = await _patient.PostAsync(RequestUrl + 1, content);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var hospitalInResponse = JsonConvert.DeserializeObject<Orchestrators.Hospitals.Hospital>(stringResponse);

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<HospitalContext>();
                var databaseHospital = await context.hospitals.FindAsync(hospitalInResponse.Id);
                Assert.AreEqual(databaseHospital.Id, hospitalInResponse.Id);
                
                Assert.AreEqual(databaseHospital.Address, hospitalInResponse.Address);
            }
        }
        [Test]
        public async Task hospitalsController_Update_UpdatesHospitalInDatabase()
        {
            var hospital = new Orchestrators.Hospitals.Hospital { Id = 1, Count = 1843};
            var content = new StringContent(await JsonConvert.SerializeObjectAsync(hospital), Encoding.UTF8, "application/json");
            var httpResponse = await _patient.PatchAsync($"/api/Hospitals/{hospital.Id}", content);

            httpResponse.EnsureSuccessStatusCode();
            
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<HospitalContext>();
                var databasehospital = await context.hospitals.FindAsync(hospital.Id);
                Assert.AreEqual(hospital.Id, databasehospital.Id);
            }
        }
        [Test]
        public async Task HospitalController_DeleteById_DeletesBookFromDatabase()
        {
            var hospitalId = 1;
            var httpResponse = await _patient.DeleteAsync(RequestUrl + hospitalId);

            httpResponse.EnsureSuccessStatusCode();
            
            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<HospitalContext>();
                
                Assert.AreEqual(0, context.hospitals.Count());
            }
        }
    }
    
    
}