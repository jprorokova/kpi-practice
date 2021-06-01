using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hospital.Core.Hospitals;

namespace Hospital.Orchestrators.Hospitals
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _repository;

        public HospitalService(IHospitalRepository repository)
        {
            _repository = repository;
        }
        public async Task<Core.Hospitals.Hospital> AddHospitalAsync(Core.Hospitals.Hospital hospital)
        {
            return await _repository.AddHospitalAsync(hospital);
        }

        public async Task<Core.Hospitals.Hospital> UpdateHospitalAsync(int id, int  count)
        {
            var hospital = await _repository.GetByIdAsync(id);
            if (hospital == null)
                throw new ArgumentOutOfRangeException();
            if (count <= 0)
                throw new ArgumentOutOfRangeException();
            hospital.Count = count;
            await _repository.UpdateHospitalAsync(id, count);
            return hospital;
        }

        public async Task<List<Core.Hospitals.Hospital>> GetListAsync()
        {
            return await _repository.GetListAsync();
        }

        public async Task<Core.Hospitals.Hospital> GetByIdAsync(int id)
        {
            var hospital = await _repository.GetByIdAsync(id);
            if (hospital == null)
                throw new ArgumentOutOfRangeException();
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveById(int id)
        {
            var hospital = await _repository.GetByIdAsync(id);
            if (hospital == null)
                throw new ArgumentOutOfRangeException();
           
            await _repository.RemoveById(id);
        }
    }
}
