using AutoMapper;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        // GET: api/<DoctorsController>
        [HttpGet]
        public ActionResult<IEnumerable<DoctorDto>> Get()
        {
            var doctorsFromRepo = _doctorRepository.GetAll();

            var doctorsOutput = _mapper.Map<IEnumerable<DoctorDto>>(doctorsFromRepo);

            return Ok(doctorsOutput);
        }

        // GET api/<DoctorsController>/5
        [HttpGet("{id}", Name = "GetDoctor")]
        public ActionResult<DoctorDto> Get(int id)
        {
            var doctorFromRepo = _doctorRepository.GetById(id);
            
            if (doctorFromRepo == null)
                return NotFound();

            var doctor = _mapper.Map<DoctorDto>(doctorFromRepo);
            return Ok(doctor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] DoctorUpdateDto doctor)
        {
            var doctorFromRepo = _doctorRepository.GetById(id);
            
            if (doctorFromRepo == null)
            {
                var doctorToAdd = _mapper.Map<Doctor>(doctor);
                doctorToAdd.DoctorId = id;

                _doctorRepository.Add(doctorToAdd);
                _doctorRepository.Save();

                var doctorToReturn = _mapper.Map<DoctorDto>(doctorToAdd);

                return CreatedAtRoute("GetDoctor",
                        new { id = id}, doctorToReturn);
            }
            _mapper.Map(doctor, doctorFromRepo);

            _doctorRepository.Update(doctorFromRepo);
            _doctorRepository.Save();
            return NoContent();
        }

        // DELETE api/<DoctorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var doctor = _doctorRepository.GetById(id);

            if (doctor == null)
                return NotFound();

            _doctorRepository.Remove(doctor);
            _doctorRepository.Save();

            return NoContent();
        }
    }
}
