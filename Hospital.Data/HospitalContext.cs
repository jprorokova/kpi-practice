using Microsoft.EntityFrameworkCore;

namespace Hospital.Data
{
    public class HospitalContext : DbContext
    {
        public DbSet<Hospitals.Hospital> hospitals { get; set; }
        public DbSet<Patients.Patient> patients { get; set; }
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
