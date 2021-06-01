
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Core.Patients;
using Hospital.Orchestrators.Patient;
using Microsoft.AspNetCore.Mvc;
using Patient = Hospital.Orchestrators.Patient.Patient;

namespace Hospital.Onion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;
        private readonly IMapper _mapper;

        public PatientsController(IPatientService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var entity = await _service.GetListAsync();
            return Ok(_mapper.Map<List<Patient>>(entity));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var patient = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<Patient>(patient));
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> PostAsync(Patient patient)
        {
            var patientModel = _mapper.Map<Core.Patients.Patient>(patient);
            var createdModel = await _service.AddPatientAsync(patientModel);
            return Ok(_mapper.Map<Patient>(createdModel));
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCount(int id, UpdateSum sum)
        {
            await _service.UpdatePatientAsync(id, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> GetAsync(int Id)
        {
            await _service.RemoveById(Id);
            return Ok();

        }

    }
}
