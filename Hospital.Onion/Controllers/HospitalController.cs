using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Core.Hospitals;
using Hospital.Onion.HospitalContract;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Onion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Hospital : ControllerBase
    {
        private readonly IHospitalService _service;
        private readonly IMapper _mapper;

        public Hospital(IHospitalService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var entity = await _service.GetListAsync();
            return Ok(_mapper.Map<List<HospitalContract.Hospital>>(entity));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Banks = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<List<HospitalContract.Hospital>>(Banks));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(HospitalContract.Hospital hospital)
        {
            var bankModel = _mapper.Map<Core.Hospitals.Hospital>(hospital);
            var createdModel = await _service.AddHospitalAsync(bankModel);
            return Ok(_mapper.Map<HospitalContract.Hospital>(createdModel));


        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCount(int id, UpdateCount count)
        {
            await _service.UpdateHospitalAsync(id, id);
            return Ok(_mapper.Map<HospitalContract.Hospital>(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> GetAsync(int Id)
        {
            await _service.RemoveById(Id);
            return Ok();

        }
    }
}
