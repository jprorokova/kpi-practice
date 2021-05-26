using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hospital.Onion;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Tests
{
    public class PatientTest :
    IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _patient;
        private readonly CustomWebApplicationFactory<Startup>
            _factory;

        public PatientTest(
            CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _patient = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task PostAsync_IfRecordInserted_ReturnOk()
        {
            // Arrange
            int hospitalId = 1;
            global::Hospital.Orchestrators.Patients.PatientService patients = new global::Hospital.Orchestrators.Patients.PatientService()
            {
                Id = 5,
                Name = "gggg",
                SurName = "hhhh",
                Birthday = "21.08.1994",
                Sum = 13123
            };
            var request = new HttpRequestMessage(HttpMethod.Post, $"/Hospital/{hospitalId}/Hospital")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                        patients),
                    Encoding.UTF8,
                    "application/json")
            };

            //Act
            var responce = await _patient.SendAsync(request);

            // Assert
            responce.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, responce.StatusCode);

        }

        [Fact]
        public async Task patientsListGetAsync_IfCorrectListReturned_ReturnOk()
        {
            // Arrange
            int hospitalId = 1;
            int sum = 1000;
            string name = "fwefwe";
            string secondName = "ewfwefwef";
            global::Hospital.Orchestrators.Patients.PatientService patient1 = new global::Hospital.Orchestrators.Patients.PatientService()
            {
                Id = Id,
                Name = name,
                SecondName = secondName,
                Sum = sum
            };
            
            var firstPostRequest = new HttpRequestMessage(HttpMethod.Post, $"/Hospital/{hospitalId}/Hospital")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                        patient1),
                    Encoding.UTF8,
                    "application/json")
            };
            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"/Hospital/{hospitalId}/Hospital?");
            //Act
            var firstPostResponce = await _patient.SendAsync(firstPostRequest);

            var getResponce =  await _patient.SendAsync(getRequest);
            var patients = await getModelListFromHttpResponce(getResponce);

            // Assert
            firstPostResponce.EnsureSuccessStatusCode();
            getResponce.EnsureSuccessStatusCode();
            Assert.Equal(2, patients.Count);
            Assert.Equal(patient1.Sum, patient1.Sum);
        }
        [Fact]
        public async Task clientsDeleteAsync_IfRecordDeleted_ReturnOk()
        {
            // Arrange
            int hospitalId = 3;
            global::Hospital.Orchestrators.Patients.PatientService patients = new global::Hospital.Orchestrators.Patients.PatientService()
            {
                Name = "edqwqw",
                SecondName = "secondName",
                Sum = 123
            };
            
            var firstPostRequest = new HttpRequestMessage(HttpMethod.Post, $"/Hospital/{hospitalId}/Hospital?")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                        patients),
                   Encoding.UTF8,
                   "application/json")
            };

            //Act
            var firstPostResponce = await _patient.SendAsync(firstPostRequest);
            var record = await getModelFromHttpResponce(firstPostResponce);

            var deleteResponce = await _patient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"/Hospital/Patient?patientId={patients.Id}"));
            var exception = await Assert.ThrowsAsync<System.InvalidOperationException>
                (async () => await _patient.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"/Hospital/Patient?patientId={patients.Id}")));

            // Assert
            firstPostResponce.EnsureSuccessStatusCode();
            deleteResponce.EnsureSuccessStatusCode();
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task RecordUpdateAsync_IfRecordUpdated_ReturnOk()
        {
            // Arrange
            int bankId = 1;
            global::Hospital.Orchestrators.Patients.PatientService patients1 = new global::Hospital.Orchestrators.Patients.PatientService()
            {
                Name = "edqwqw",
                SecondName = "secondName",
                Sum = 123
            };
            global::Hospital.Orchestrators.Patients.PatientService clients2 = new global::Hospital.Orchestrators.Patients.PatientService()
            {
                Name = "edqwffdsfsqw",
                SecondName = "sefdsfsdcondName",
                Sum = 1223
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, $"/Hospital/{hospitalId}/Hospital?")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                      patients1),
                   Encoding.UTF8,
                   "application/json")
            };

            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"/Hospital/{bankId}/Client?");

            //Act
            var postResponce = await _patient.SendAsync(postRequest);
            var record = await getModelFromHttpResponce(postResponce);

            var updatedResponce = await _patient.SendAsync(new HttpRequestMessage(HttpMethod.Put, $"/Hospital/Client?bankId={patients1.Id}")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                      clients2),
                   Encoding.UTF8,
                   "application/json")
            });

            var getResponce = await _patient.SendAsync(getRequest);
            var recordList = await getModelListFromHttpResponce(getResponce);

            // Assert
            postResponce.EnsureSuccessStatusCode();
            updatedResponce.EnsureSuccessStatusCode();
            Assert.Equal(patients1.Id, recordList[0].Id);
            Assert.Equal(clients2.Sum, recordList[0].Sum);
        }
       
        [Fact]
        public async Task RecordPatchAsync_IfRecordPatched_ReturnOk()
        {
            // Arrange
            int userId = 1;
            int addedAmount = 10000;

            global::Hospital.Orchestrators.Patients.PatientService patients = new global::Hospital.Orchestrators.Patients.PatientService()
            {
                Name = "edqwffdsfsqw",
                SecondName = "sefdsfsdcondName",
                Sum = 1223
            };
            var postRequest = new HttpRequestMessage(HttpMethod.Post, $"/User/{userId}/Record")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                      patients),
                   Encoding.UTF8,
                   "application/json")
            };

            //Act
            var postResponce = await _patient.SendAsync(postRequest);
            var record = await getModelFromHttpResponce(postResponce);

            var patchResponce = await _patient.SendAsync(
                new HttpRequestMessage(HttpMethod.Patch, $"/User/Record?newAmount={addedAmount}&recordId={record.Id}"));

            var getResponce = await _patient.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"/User/Record?recordId={record.Id}"));
            record = await getModelFromHttpResponce(getResponce);

            // Assert
            patchResponce.EnsureSuccessStatusCode();
            postResponce.EnsureSuccessStatusCode();
            Assert.Equal(addedAmount + patients.Sum, patients.Sum);
        }
        [Fact]
        public async Task RecordPatchAsync_IfThrowsOverflowException_ReturnOk()
        {
            // Arrange
            int bankId = 1;

            global::Hospital.Orchestrators.Patients.PatientService patients = new global::Hospital.Orchestrators.Patients.PatientService()
            {
                Name = "edqwffdsfsqw",
                SecondName = "sefdsfsdcondName",
                Sum = 1223
            };
            var postRequest = new HttpRequestMessage(HttpMethod.Post, $"/User/{hospitalId}/Record")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                      patients),
                   Encoding.UTF8,
                   "application/json")
            };

            int newAmount = int.MaxValue;
            int recordId = 1;

            var updateRequest = new HttpRequestMessage(HttpMethod.Patch, $"/User/Record?newAmount={newAmount}&recordId={recordId}");

            //Act
            var postResponce = await _patient.SendAsync(postRequest);
            var exception = await Assert.ThrowsAsync<System.OverflowException>(async () => await _patient.SendAsync(updateRequest));

            // Assert
            postResponce.EnsureSuccessStatusCode();
            Assert.NotNull(exception);
        }
        [Fact]
        public async Task RecordDeleteListAsync_IfWorks_ReturnOk()
        {
            // Arrange
            int categoryId = 1;
            int userId = 1;
            int amount = 1000;
            DateTime firstInsertedDate = new DateTime(2001, 10, 20);
            DateTime secondInsertedDate = new DateTime(2001, 10, 23);
            DateTime endDate = new DateTime(2001, 10, 26);
            global::Hospital.Orchestrators.Patients.PatientService firstPatient = new global::Hospital.Orchestrators.Patients.PatientService()
            {
                Name = "edqwffdsfsqw",
                SecondName = "sefdsfsdcondName",
                Sum = 1223
            };
            global::Hospital.Orchestrators.Patients.PatientService secondPatient = new global::Hospital.Orchestrators.Patients.PatientService()
            {
                Name = "edqwffdsfsqw",
                SecondName = "sefdsfsdcondName",
                Sum = 1223
            };

            var PostRequest = new HttpRequestMessage(HttpMethod.Post, $"/Hospital/{userId}/Patient")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                        firstPatient),
                    Encoding.UTF8,
                    "application/json")
            };

            var deleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"/Hospital/{userId}/Patient");
            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"/Hospital/{userId}/Patient");

            //Act
            var PostResponce = await _patient.SendAsync(PostRequest);
            var DeleteResponce = await _patient.SendAsync(deleteRequest);
            var GetResponce = await _patient.SendAsync(getRequest);

            var patients = await getModelListFromHttpResponce(GetResponce);
            // Assert
            PostResponce.EnsureSuccessStatusCode();
            DeleteResponce.EnsureSuccessStatusCode();
            GetResponce.EnsureSuccessStatusCode();
            Assert.Empty(patients);
        }

        async Task<global::Hospital.Orchestrators.Patients.PatientService> getModelFromHttpResponce(HttpResponseMessage responce)
        {
            var byteResult = await responce.Content.ReadAsByteArrayAsync();
            var stringResult = Encoding.UTF8.GetString(byteResult);
            var record = JsonConvert.DeserializeObject<global::Hospital.Orchestrators.Patients.PatientService>(stringResult);
            return record;
        }

        async Task<List<global::Hospital.Orchestrators.Patients.PatientService>> getModelListFromHttpResponce(HttpResponseMessage responce)
        {
            var byteResult = await responce.Content.ReadAsByteArrayAsync();
            var stringResult = Encoding.UTF8.GetString(byteResult);
            var patients = JsonConvert.DeserializeObject<List<Hospital.Orchestrators.Patients.PatientService>>(stringResult);
            return patients;
        }
    }
}