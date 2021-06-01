using System;
using System.Linq;
using Hospital.Data;
using Hospital.Onion;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;
using TestProject1;

namespace Hospital.Tests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                RemoveLibraryDbContextRegistration(services);

                var serviceProvider = GetInMemoryServiceProvider();

                services.AddDbContextPool<HospitalContext>(options =>
                {
                    options.UseInMemoryDatabase(Guid.Empty.ToString());
                    options.UseInternalServiceProvider(serviceProvider);
                });

                using (var scope = services.BuildServiceProvider().CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<HospitalContext>();

                    UnitTestHelper.SeedData(context);
                }
            });
        }
        private static ServiceProvider GetInMemoryServiceProvider()
        {
            return new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
        }
        private static void RemoveLibraryDbContextRegistration(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<HospitalContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }
    }
}