using AutoMapper;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DoctorWho.Web.Controllers
{
    [Route("api/episodes")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeRepository _episodeRepository;
        private readonly IMapper mapper;
        private readonly IValidator<EpisodeInputDto> validator;

        public EpisodesController(IEpisodeRepository episodeRepository
            , IMapper mapper
            , IValidator<EpisodeInputDto> validator)
        {
            _episodeRepository = episodeRepository;
            this.mapper = mapper;
            this.validator = validator;
        }
        // GET: api/<EpisodesController>
        [HttpGet]
        public ActionResult<IEnumerable<EpisodeDto>> Get()
        {
            var episodesFromRepo = _episodeRepository.GetAll();

            var episodesOutput = mapper.Map<IEnumerable<EpisodeDto>>(episodesFromRepo);

            return Ok(episodesOutput);
        }

        // GET api/<EpisodesController>/5
        [HttpGet("{id}", Name = "GetEpisode")]
        public ActionResult<EpisodeDto> Get(int id)
        {
            var episodeFromRepo = _episodeRepository.GetById(id);

            if (episodeFromRepo == null)
                return NotFound();

            var episode = mapper.Map<EpisodeDto>(episodeFromRepo);
            return Ok(episode);
        }

        // POST api/<EpisodesController>
        [HttpPost()]
        public ActionResult<EpisodeDto> Create([FromBody] EpisodeInputDto episode)
        {
            var result = validator.Validate(episode);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            var episodeToAdd = mapper.Map<Episode>(episode);

            _episodeRepository.Add(episodeToAdd);
            _episodeRepository.Save();

            var episodeToReturn = mapper.Map<EpisodeDto>(episodeToAdd);

            return CreatedAtRoute("GetEpisode",
                    new { id = episodeToReturn.EpisodeId }, episodeToReturn);
        }

    }
}
