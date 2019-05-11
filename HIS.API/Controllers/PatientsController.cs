using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HIS.API.Helpers;
using HIS.Core.Dtos;
using HIS.Core.Entities;
using HIS.Core.Enums;
using HIS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HIS.API.Controllers
{
    [Route("his/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository _repository;
        public IMapper _mapper { get; }

        public PatientsController(IRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetPatients([FromQuery]SearchParams searchParams)
        {
            var patients = await _repository.List<Patient>(searchParams);
            var patientsDtos = _mapper.Map<IEnumerable<PatientListDto>>(patients);
            Response.AddPagination(patients.CurrentPage, patients.PageSize, patients.TotalCount, patients.TotalPages);

            return Ok(patientsDtos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var patient = await _repository.GetById<Patient>(id);
            return Ok(patient);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Patient patient)
        {
            patient.CreationDate = DateTime.Now;
            _repository.Add<Patient>(patient);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
