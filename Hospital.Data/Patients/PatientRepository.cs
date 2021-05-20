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
            var clientEntitye = _mapper.Map<Patient>(patient);
            var result = await _context.clients.AddAsync(clientEntitye);
            return _mapper.Map<Core.Patients.Patient>(result.Entity);
        }

        public async Task<Core.Patients.Patient> UpdatePatientAsync(int id, int sum)
        {
            var entitie = _mapper.Map<Core.Patients.Patient>(sum);
            var result = _context.Update(entitie);
            return _mapper.Map<Core.Patients.Patient>(entitie);
        }

        public async Task<List<Core.Patients.Patient>> GetListAsync()
        {
            var enteties = await _context.clients.ToListAsync();
            return _mapper.Map<List<Core.Patients.Patient>>(enteties);
        }

        public async Task<Core.Patients.Patient> GetByIdAsync(int id)
        {
            var entetie = await _context.clients.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Core.Patients.Patient>(entetie);
        }

        public async Task RemoveById(int id)
        {
            var entitie = await _context.clients.FirstOrDefaultAsync(x => x.Id == id);
            _context.clients.Remove(entitie);
        }
    }
}
