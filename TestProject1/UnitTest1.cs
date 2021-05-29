using System;
using AutoMapper;
using Hospital.Core.Patients;
using Hospital.Data;
using Hospital.Data.Hospitals;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    public class UnitTestHelper
    {
        public static DbContextOptions<HospitalContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<HospitalContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (var context = new HospitalContext(options))
            {
                SeedData(context);
            }
            return options;
        }

        public static void SeedData(HospitalContext context)
        {
            context.hospitals.Add(new Hospital.Data.Hospitals.Hospital { Id = 1, Count = 12313, Address = "190" });
            context.patients.Add(new Hospital.Data.Patients.Patient() { Id = 1, Name = "gggg", SurName = "deeee", Sum = 332412 });
            context.SaveChanges();
        }

        public static Mapper CreateMapperProfile()
        {
            var myProfile = new HospitalDaoProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }
    }
}