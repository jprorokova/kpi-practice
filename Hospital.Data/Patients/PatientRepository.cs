using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Core.Patients;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Data.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IMapper _mapper;
        private readonly HospitalContext _context;

        public PatientRepository(IMapper mapper, HospitalContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Core.Patients.Patient> AddPatientAsync(Core.Patients.Patient patient)
        {
            var patientNew = _mapper.Map<Patient>(patient);
            var addAsync = await _context.patients.AddAsync(patientNew);
            await _context.SaveChangesAsync();
            return _mapper.Map<Core.Patients.Patient>(addAsync.Entity);
        }

        public async Task<Core.Patients.Patient> UpdatePatientAsync(int id, int sum)
        {
            var entity = await _context.patients.FirstAsync(x => x.Id == id);
            entity.Sum = sum;
            var result = _context.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Core.Patients.Patient>(result.Entity);
        }

        public async Task<List<Core.Patients.Patient>> GetListAsync()
        {
            var enteties = await _context.patients.ToListAsync();
            return _mapper.Map<List<Core.Patients.Patient>>(enteties);
        }

        public async Task<Core.Patients.Patient> GetByIdAsync(int id)
        {
            var entetie = await _context.patients.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Core.Patients.Patient>(entetie);
        }

        public async Task RemoveById(int id)
        {
            var entitie = await _context.patients.FirstAsync(x => x.Id == id);
            _context.patients.Remove(entitie);
            await _context.SaveChangesAsync();
        }
    }
}
