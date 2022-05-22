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
    [Route("api/subjects")]
    public class SubjectsController : Controller
    {
        private readonly IGenericRepository<Subject> _subjectsRepository;

        public SubjectsController(IGenericRepository<Subject> subjectsRepository)
        {
            this._subjectsRepository = subjectsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects([FromQuery] PageParameters pageParameters)
        {
            var subjects = await this._subjectsRepository.GetPageAsync(pageParameters);
            var metadata = new
            {
                subjects.TotalItems,
                subjects.PageSize,
                subjects.PageNumber,
                subjects.TotalPages,
                subjects.HasNextPage,
                subjects.HasPreviousPage
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return subjects;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
            var subject = await this._subjectsRepository.GetOneAsync(id, s => s.Teachers);
            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Subject subject)
        {
            if (ModelState.IsValid)
            {
                if (await this._subjectsRepository.ExistsAsync(t => t.Name == subject.Name))
                {
                    ModelState.AddModelError(string.Empty, "Subject with this name already exists!");
                }
                else
                {
                    this._subjectsRepository.Attach(subject);
                    await this._subjectsRepository.AddAsync(subject);
                    return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Subject subject)
        {
            if (ModelState.IsValid)
            {
                if (await this._subjectsRepository.ExistsAsync(c => c.Name == subject.Name && c.Id != id))
                {
                    ModelState.AddModelError(string.Empty, "Subject with this name already exists!");
                }
                else
                {
                    this._subjectsRepository.Attach(subject);
                    await this._subjectsRepository.UpdateAsync(subject);
                    return NoContent();
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await this._subjectsRepository.GetOneAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            await this._subjectsRepository.DeleteAsync(subject);

            return NoContent();
        }
    }
}
