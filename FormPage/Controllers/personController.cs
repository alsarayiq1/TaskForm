using AutoMapper;
using FormPage.Dto;
using FormPage.Entity;
using FormPage.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormPage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository<PersonInfo> _PersonRepository;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository<PersonInfo> PersonRepository, IMapper mapper)
        {
            _PersonRepository = PersonRepository;
            _mapper = mapper;
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonInfo>>> GetPeople()
        {
            return Ok(await _PersonRepository.GetAll());
        }

        // GET: api
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonInfo>> GetPerson(int PersonInfoId)
        {
            var person = await _PersonRepository.GetById(PersonInfoId);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }



        // PUT: api
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int PersonInfoId, PersonInfo person)
        {
            if (PersonInfoId != person.PersonInfoId)
            {
                return BadRequest();
            }

            try
            {
                await _PersonRepository.Update(person);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int PersonInfoId)
        {
            try
            {
                await _PersonRepository.Delete(PersonInfoId);
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
        public IActionResult CreatePerson([FromBody] PersonDto PersonCreate)
        {
            if (PersonCreate == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var personMap = _mapper.Map<PersonInfo>(PersonCreate);

            if (!_PersonRepository.PersonCreate(personMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }



    }
}
