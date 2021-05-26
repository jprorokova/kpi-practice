using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hospital.Core;
using Hospital.Onion;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Tests
{
    public class UnitTest1
    :
    IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _cliento;
        private readonly CustomWebApplicationFactory<Startup>
            _factory;

        public UnitTest1(
            CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _cliento = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task GetAsync_IfServiceReturnsCorrecthospital_ReturnOk()
        {
            // Arrange
            var postedHospital = new global::Hospital.Orchestrators.Hospitals.HospitalService()
            {
                Id = 1312,
                Address = "jjkk",
                
            };

            var addRequest = new HttpRequestMessage(HttpMethod.Post, "/Hospital")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                    postedHospital), 
                    Encoding.UTF8, "application/json")
            };

            //Act
            var addResponse = await _cliento.SendAsync(addRequest);
            var hospital = await getModelFromHttpResponce(addResponse);

            var getResponse = await _cliento.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"/Hospital?id={hospital.Id}"));
            hospital = await getModelFromHttpResponce(getResponse);

            // Assert
            addResponse.EnsureSuccessStatusCode();
            getResponse.EnsureSuccessStatusCode();
            Assert.Equal(postedHospital.Id, hospital.Id);
            Assert.Equal(postedHospital.Address, hospital.Address);
           
        }

        [Fact]
        public async Task GetAsync_IfServiceThrowsExceptionWhenIdUndefined_ReturnOk()
        {
            // Arrange
            int undefinedId = 99999;

            var getRequest = new HttpRequestMessage(HttpMethod.Get, $"/Hospital?hospitalId={undefinedId}");
            //Act

            var exception = await Assert.ThrowsAsync<System.InvalidOperationException>(async () => await _cliento.SendAsync(getRequest));

            // Assert
            Assert.NotNull(exception);

        }

        [Fact]
        public async Task PostAsync_IfServiceReturnshospital_ReturnOk()
        {
            // Arrange
            var postinHospital = new global::Hospital.Orchestrators.Hospitals.HospitalService()
            {
                Address = "jjkk",
                
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "/Hospital")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                        postinHospital),
                    Encoding.UTF8, "application/json")
            };

            //Act
            var response = await _cliento.SendAsync(request);

            var byteResult = await response.Content.ReadAsByteArrayAsync();
            var stringResult = Encoding.UTF8.GetString(byteResult);
            var hospital = JsonConvert.DeserializeObject<global::Hospital.Core.Hospitals.Hospital>(stringResult);

            // Assert
            response.EnsureSuccessStatusCode();

            Assert.Equal(postinHospital.Address, hospital.Address);
            
        }

        [Fact]
        public async Task PatcAsync_IfLoginCorrect_ReturnOk()
        {
            // Arrange
            var addedHospital = new global::Hospital.Core.Hospitals.Hospital()
            {
                Address = "gg",
                
            };
            var updatedUpdate = new global::Hospital.Orchestrators.Hospitals.HospitalService()
            {
                Address = "gg"

            };
            var postRequest = new HttpRequestMessage(HttpMethod.Post, $"/Hospital")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                        addedHospital),
                    Encoding.UTF8,
                    "application/json")
            };

            //Act
            var postResponce = await _cliento.SendAsync(postRequest);
            var hospital = await getModelFromHttpResponce(postResponce);

            var patchResponce = await _cliento.SendAsync(new HttpRequestMessage(HttpMethod.Patch, $"/Hospital?hospitalId={hospital.Id}&newLogin={updatedUpdate.Count}"));

            var getResponce = await _cliento.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"/Hospital?hospitalId={hospital.Id}"));
            hospital = await getModelFromHttpResponce(getResponce);

            // Assert
            postResponce.EnsureSuccessStatusCode();
            patchResponce.EnsureSuccessStatusCode();
            getResponce.EnsureSuccessStatusCode();

            Assert.Equal(updatedUpdate.Address, updatedUpdate.Address);
            
        }

        [Fact]
        public async Task PosthospitalWithExistingLogin_IfProgramThrowException_ReturnOk()
        {
            // Arrange
            var hospital = new global::Hospital.Orchestrators.Hospitals.HospitalService()
            {
                Address = "jjkk",
                
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "/Hospital")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                        new global::Hospital.Orchestrators.Hospitals.HospitalService
                        {
                            Address = "jjkk",
                            
                        }),
                    Encoding.UTF8,
                    "application/json")
            };

            var duplicateRequest = new HttpRequestMessage(HttpMethod.Post, "/Hospital")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                        new global::Hospital.Orchestrators.Hospitals.HospitalService
                        {
                            Address = "jjkk",
                            
                        }),
                    Encoding.UTF8,
                    "application/json")
            };

            //Act
            var response = await _cliento.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var exception = await Assert.ThrowsAsync<FailedInsertionException>(async () => await _cliento.SendAsync(duplicateRequest));

            // Assert
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task Deletehospital_IfWorksAndSecondDeleteThrowsException_ReturnOk()
        {
            // Arrange
            var postedhospital = new global::Hospital.Orchestrators.Hospitals.HospitalService()
            {
                Location = "jjkk",
                
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Hospital")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                        postedhospital),
                    Encoding.UTF8,
                    "application/json")
            };

            //Act
            var postResponse = await _cliento.SendAsync(postRequest);
            var hospital = await getModelFromHttpResponce(postResponse);

            var deleteResponce = await _cliento.SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"/Hospital?HospitalId={hospital.Id}"));
  
            var exception = await Assert.ThrowsAsync<AlreadyDeletedException>(async () => await _cliento.SendAsync
            (new HttpRequestMessage(HttpMethod.Delete, $"/Hospital?hospitalId={hospital.Id}")));

            // Assert
            postResponse.EnsureSuccessStatusCode();
            deleteResponce.EnsureSuccessStatusCode();

            Assert.NotNull(exception);
        }

        [Fact]
        public async Task GetAndPatchDeletedhospital_IfThrowsException_ReturnOk()
        {
            // Arrange
            var postedhospital = new global::Hospital.Orchestrators.Hospitals.HospitalService()
            {
                Address = "jjkk",
                
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Hospital")
            {
                Content = new StringContent(JsonConvert.SerializeObject(
                        postedhospital),
                    Encoding.UTF8,
                    "application/json")
            };

            //Act
            var postResponse = await _cliento.SendAsync(postRequest);
            var hospital = await getModelFromHttpResponce(postResponse);

            var deleteResponce = await _cliento.SendAsync(new HttpRequestMessage(HttpMethod.Delete, $"/Hospital?hospitalId={hospital.Id}"));

            var onPostException = await Assert.ThrowsAsync<AlreadyDeletedException>(async () => await _cliento.SendAsync(
                new HttpRequestMessage(HttpMethod.Get, $"/hospital?hospitalId={hospital.Id}")));

            // Assert
            postResponse.EnsureSuccessStatusCode();
            deleteResponce.EnsureSuccessStatusCode();
            Assert.NotNull(onPostException);
            
        }

        async Task<global::Hospital.Core.Hospitals.Hospital> getModelFromHttpResponce(HttpResponseMessage responce)
        {
            var byteResult = await responce.Content.ReadAsByteArrayAsync();
            var stringResult = Encoding.UTF8.GetString(byteResult);
            var record = JsonConvert.DeserializeObject<global::Hospital.Core.Hospitals.Hospital>(stringResult);
            return record;
        }
    }
}