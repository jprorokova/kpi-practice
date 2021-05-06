using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Core.Patients
{
    public interface IPatientRepository
    {
        Task<Patient> AddPatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(int id, int sum);
        Task<List<Patient>> GetListAsync();
        Task<Patient> GetByIdAsync(int id);
        Task RemoveById(int id);
    }
}
