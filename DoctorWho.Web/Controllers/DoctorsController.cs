using AutoMapper;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DoctorUpdateDto> _validator;

        public DoctorController(IDoctorRepository doctorRepository
            , IMapper mapper
            , IValidator<DoctorUpdateDto> validator)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _validator = validator;
        }
        // GET: api/<DoctorsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> Get()
        {
            var doctorsFromRepo = await _doctorRepository.GetAll();

            var doctorsOutput = _mapper.Map<IEnumerable<DoctorDto>>(doctorsFromRepo);

            return Ok(doctorsOutput);
        }

        // GET api/<DoctorsController>/5
        [HttpGet("{id}", Name = "GetDoctor")]
        public async Task<ActionResult<DoctorDto>> Get(int id)
        {
            var doctorFromRepo = await _doctorRepository.GetById(id);
            
            if (doctorFromRepo == null)
                return NotFound();

            var doctor = _mapper.Map<DoctorDto>(doctorFromRepo);
            return Ok(doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] DoctorUpdateDto doctor)
        {
            var result = _validator.Validate(doctor);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var doctorFromRepo = await _doctorRepository.GetById(id);
            
            if (doctorFromRepo == null)
            {
                var doctorToAdd = _mapper.Map<Doctor>(doctor);
                doctorToAdd.DoctorId = id;

                await _doctorRepository.Add(doctorToAdd);
                await _doctorRepository.Save();

                var doctorToReturn = _mapper.Map<DoctorDto>(doctorToAdd);

                return CreatedAtRoute("GetDoctor",
                        new { id = id}, doctorToReturn);
            }
            _mapper.Map(doctor, doctorFromRepo);

            _doctorRepository.Update(doctorFromRepo);
            await _doctorRepository.Save();

            return NoContent();
        }

        // DELETE api/<DoctorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorRepository.GetById(id);

            if (doctor == null)
                return NotFound();

            _doctorRepository.Remove(doctor);
            await _doctorRepository.Save();

            return NoContent();
        }
    }
}
