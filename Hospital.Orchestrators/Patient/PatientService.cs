using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Core.Patients;

namespace Hospital.Orchestrators.Clients
{
    public class PatientService : IPatientService
    {
        public readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }
        public async Task<Core.Patients.Patient> AddPatientAsync(Core.Patients.Patient patient)
        {
            return await _repository.AddPatientAsync(patient);
        }

        public async Task<Core.Patients.Patient> UpdatePatientAsync(int id, int sum)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient == null)
                throw new ArgumentOutOfRangeException();
            if (sum <= 0)
                throw new ArgumentOutOfRangeException();
            patient.Sum = sum;
            await _repository.UpdatePatientAsync(id, sum);
            return patient;
        }

        public async Task<List<Core.Patients.Patient>> GetListAsync()
        {
            return await _repository.GetListAsync();
        }

        public async Task<Core.Patients.Patient> GetByIdAsync(int id)
        {
            
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveById(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient == null)
                throw new ArgumentOutOfRangeException();
            await _repository.RemoveById(id);
        }
    }
}
