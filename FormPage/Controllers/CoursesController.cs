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
    public class CoursesController : ControllerBase
    {
        private readonly IcoursesRepository _CoursesRepository;
        private readonly IMapper _mapper;

        public CoursesController(IcoursesRepository CoursesRepository, IMapper mapper)
        {
           _CoursesRepository = CoursesRepository;
            _mapper = mapper;
        }

        // GET: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Courses>>> GetPeople()
        {
            return Ok(await _CoursesRepository.GetAll());
        }

        // GET: api
        [HttpGet("{id}")]
        public async Task<ActionResult<Courses>> GetCourses(int id)
        {
            var Courses = await _CoursesRepository.GetById(id);

            if (Courses == null)
            {
                return NotFound();
            }

            return Courses;
        }



        // PUT: api
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourses(int id, Courses Courses)
        {
            if (id != Courses.PersonInfoId)
            {
                return BadRequest();
            }

            try
            {
                await _CoursesRepository.Update(Courses);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourses(int id)
        {
            try
            {
                await _CoursesRepository.Delete(id);
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
        public IActionResult CreateCourse([FromBody] CoursesDto CoursesCreate)
        {
            if (CoursesCreate == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var coursesMap = _mapper.Map<Courses>(CoursesCreate);

            if (!_CoursesRepository.CoursesCreate(coursesMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

    }
}
