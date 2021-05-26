using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Core.Hospitals;
using Microsoft.EntityFrameworkCore;


namespace Hospital.Data.Hospitals
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly IMapper _mapper;
        private readonly HospitalContext _context;

        public HospitalRepository(IMapper mapper, HospitalContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Core.Hospitals.Hospital> AddHospitalAsync(Core.Hospitals.Hospital hospital)
        {
            var entity = _mapper.Map<Hospital>(hospital);
            var result = await _context.hospitals.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Core.Hospitals.Hospital>(result.Entity);
        }

        public async Task<Core.Hospitals.Hospital> UpdateHospitalAsync(int id, int count)
        {
            var entitie =_mapper.Map<Hospital>(count);
            var result = _context.Update(entitie);
            return _mapper.Map<Core.Hospitals.Hospital>(result.Entity);
        }

        public async Task<List<Core.Hospitals.Hospital>> GetListAsync()
        {
            var enteties = await _context.hospitals.ToListAsync();
            return _mapper.Map<List<Core.Hospitals.Hospital>>(enteties);
        }

        public async Task<Core.Hospitals.Hospital> GetByIdAsync(int id)
        {
            var entitie = await _context.hospitals.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Core.Hospitals.Hospital>(entitie);
        }

        public async Task RemoveById(int id)
        {
            var entetie = await _context.hospitals.FirstOrDefaultAsync(x => x.Id == id);
            _context.hospitals.Remove(entetie);
        }
    }

}
