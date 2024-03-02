using AutoMapper;
using FormPage.Dto;
using FormPage.Entity;
using FormPage.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceRepository _ExperienceRepository;
        private readonly IMapper _mapper;


        public ExperienceController(IExperienceRepository ExperienceRepository, IMapper mapper)
        {
            _ExperienceRepository = ExperienceRepository;
            _mapper = mapper;
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetExperience()
        {
            return Ok(await _ExperienceRepository.GetAll());
        }

        // GET: api
        [HttpGet("{id}")]
        public async Task<ActionResult<Experience>> GetExperience(int id)
        {
            var Experience = await _ExperienceRepository.GetById(id);

            if (Experience == null)
            {
                return NotFound();
            }

            return Experience;
        }



        // PUT: api
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperience(int id, Experience Experience)
        {
            if (id != Experience.Id)
            {
                return BadRequest();
            }

            try
            {
                await _ExperienceRepository.Update(Experience);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            try
            {
                await _ExperienceRepository.Delete(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateExp([FromBody] ExperienceDto ExpCreate)
        {
            if (ExpCreate == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ExpMap = _mapper.Map<Experience>(ExpCreate);

            if (!_ExperienceRepository.ExpCreate(ExpMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

    }
}


