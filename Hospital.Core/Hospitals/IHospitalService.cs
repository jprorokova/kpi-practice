using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.Core.Hospitals
{
    public interface IHospitalService
    {
        Task<Hospital> AddHospitalAsync(Hospital hospital);
        Task<Hospital> UpdateHospitalAsync(int id, int count);
        Task<List<Hospital>> GetListAsync();
        Task<Hospital> GetByIdAsync(int id);
        Task RemoveById(int id);
    }
}
