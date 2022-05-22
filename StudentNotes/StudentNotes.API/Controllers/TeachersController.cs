using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentNotes.Application.IRepositories;
using StudentNotes.Application.Paging;
using StudentNotes.Core.Entities;

namespace StudentNotes.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : Controller
    {
        private readonly IGenericRepository<Teacher> _teachersRepository;

        public TeachersController(IGenericRepository<Teacher> teachersRepository)
        {
            this._teachersRepository = teachersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers([FromQuery] PageParameters pageParameters)
        {
            var teachers = await this._teachersRepository.GetPageAsync(pageParameters);
            var metadata = new
            {
                teachers.TotalItems,
                teachers.PageSize,
                teachers.PageNumber,
                teachers.TotalPages,
                teachers.HasNextPage,
                teachers.HasPreviousPage
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return teachers;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await this._teachersRepository.GetOneAsync(id, t => t.Subjects);
            if (teacher == null)
            {
                return NotFound();
            }

            return teacher;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                if (await this._teachersRepository.ExistsAsync(t => t.Name == teacher.Name))
                {
                    ModelState.AddModelError(string.Empty, "Teacher with this name already exists!");
                }
                else
                {
                    this._teachersRepository.Attach(teacher);
                    await this._teachersRepository.AddAsync(teacher);
                    return CreatedAtAction("GetTeacher", new { id = teacher.Id }, teacher);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                if (await this._teachersRepository.ExistsAsync(c => c.Name == teacher.Name && c.Id != id))
                {
                    ModelState.AddModelError(string.Empty, "Teacher with this name already exists!");
                }
                else
                {
                    this._teachersRepository.Attach(teacher);
                    await this._teachersRepository.UpdateAsync(teacher);
                    return NoContent();
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await this._teachersRepository.GetOneAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            await this._teachersRepository.DeleteAsync(teacher);

            return NoContent();
        }
    }
}
