using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hospital.Data;
using Hospital.Orchestrators.Patient;
using Hospital.Tests;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TestProject1
{
    public class PatientTests
    {
        private HttpClient _patient;
        private CustomWebApplicationFactory _factory;
        private const string RequestUrl = "/api/Patients/";

        [SetUp]
        public void SetUp()
        {
            _factory = new CustomWebApplicationFactory();
            _patient = _factory.CreateClient();
        }
        [Test]
        public async Task patientsController_GetById_ReturnspatientModel()
        {
            var httpResponse = await _patient.GetAsync(RequestUrl + 1);

            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var patient = JsonConvert.DeserializeObject<Patient>(stringResponse);

            Assert.AreEqual(1, patient.Id);
            Assert.AreEqual("gggg", patient.Name);
            Assert.AreEqual("deeee", patient.SurName);
            Assert.AreEqual(332412, patient.Sum);
        }
        [Test]
        public async Task patientsController_Add_AddspatientToDatabase()
        {
            var patient = new Patient() { Name = "ddqqfewfwwq", SurName = "fqwewefqw",Birthday = "26/11/2005", Sum = 124242 };
            var content = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
            var httpResponse = await _patient.PostAsync(RequestUrl + 1, content);


            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var patientInResponse = JsonConvert.DeserializeObject<Patient>(stringResponse);

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<HospitalContext>();
                var databasepatient = await context.patients.FindAsync(patientInResponse.Id);
                Assert.AreEqual(databasepatient.Id, patientInResponse.Id);
                Assert.AreEqual(databasepatient.Name, patientInResponse.Name);
                Assert.AreEqual(databasepatient.SurName, patientInResponse.SurName);
                Assert.AreEqual(databasepatient.Birthday, patientInResponse.Birthday);
                Assert.AreEqual(databasepatient.Sum, patientInResponse.Sum);
            }
        }
        [Test]
        public async Task patiensController_Update_UpdatespatientInDatabase()
        {
            var patient = new Patient { Id = 1, Sum = 184 };
            var content = new StringContent(await JsonConvert.SerializeObjectAsync(patient), Encoding.UTF8, "application/json");
            var httpResponse = await _patient.PatchAsync($"/api/Patients/{patient.Id}", content);

            httpResponse.EnsureSuccessStatusCode();

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<HospitalContext>();
                var databasepatient = await context.patients.FindAsync(patient.Id);
                Assert.AreEqual(patient.Id, databasepatient.Id);
            }
        }
        [Test]
        public async Task BooksController_DeleteById_DeletesBookFromDatabase()
        {
            var patientId = 1;
            var httpResponse = await _patient.DeleteAsync("/api/Patients/" + patientId);

            httpResponse.EnsureSuccessStatusCode();

            using (var test = _factory.Services.CreateScope())
            {
                var context = test.ServiceProvider.GetService<HospitalContext>();

                Assert.AreEqual(0, context.patients.Count());
            }
        }
    }
}