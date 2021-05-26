
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hospital.Core.Patients;
using Hospital.Onion.PatientContract;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_mapper.Map<List<PatientContract.Patient>>(entity));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var Patient = await _service.GetByIdAsync(id);
            return Ok(_mapper.Map<List<PatientContract.Patient>>(Patient));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(PatientContract.Patient patient)
        {
            var patientModel = _mapper.Map<Core.Patients.Patient>(patient);
            var createdModel = await _service.AddPatientAsync(patientModel);
            return Ok(_mapper.Map<PatientContract.Patient>(createdModel));


        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCount(int id, UpdateSum sum)
        {
            await _service.UpdatePatientAsync(id, id);
            return Ok(_mapper.Map<PatientContract.Patient>(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> GetAsync(int Id)
        {
            await _service.RemoveById(Id);
            return Ok();

        }

    }
}
