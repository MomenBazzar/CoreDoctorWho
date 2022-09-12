using AutoMapper;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        // GET: api/authors
        [HttpGet]
        public ActionResult<IEnumerable<AuthorDto>> Get()
        {
            var authorsFromRepo = _authorRepository.GetAll();

            var authorsOutput = _mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);

            return Ok(authorsOutput);
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public ActionResult<AuthorDto> Get(int id)
        {
            var authorFromRepo = _authorRepository.GetById(id);
            
            if (authorFromRepo == null)
                return NotFound();

            var author = _mapper.Map<AuthorDto>(authorFromRepo);
            return Ok(author);
        }
    }
}
