using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentNotes.Application.IRepositories;
using StudentNotes.Application.Paging;
using Type = StudentNotes.Core.Entities.Type;

namespace StudentNotes.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/types")]
    public class TypesController : Controller
    {
        private readonly IGenericRepository<Type> _typesRepository;

        public TypesController(IGenericRepository<Type> typesRepository)
        {
            this._typesRepository = typesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type>>> GetTypes([FromQuery] PageParameters pageParameters)
        {
            var types = await this._typesRepository.GetPageAsync(pageParameters);
            var metadata = new
            {
                types.TotalItems,
                types.PageSize,
                types.PageNumber,
                types.TotalPages,
                types.HasNextPage,
                types.HasPreviousPage
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return types;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Type>> GetSubject(int id)
        {
            var type = await this._typesRepository.GetOneAsync(id);
            if (type == null)
            {
                return NotFound();
            }

            return type;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Type type)
        {
            if (ModelState.IsValid)
            {
                if (await this._typesRepository.ExistsAsync(t => t.Name == type.Name))
                {
                    ModelState.AddModelError(string.Empty, "Type with this name already exists!");
                }
                else
                {
                    this._typesRepository.Attach(type);
                    await this._typesRepository.AddAsync(type);
                    return CreatedAtAction("GetSubject", new { id = type.Id }, type);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Type type)
        {
            if (ModelState.IsValid)
            {
                if (await this._typesRepository.ExistsAsync(c => c.Name == type.Name && c.Id != id))
                {
                    ModelState.AddModelError(string.Empty, "Type with this name already exists!");
                }
                else
                {
                    this._typesRepository.Attach(type);
                    await this._typesRepository.UpdateAsync(type);
                    return NoContent();
                }
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var type = await this._typesRepository.GetOneAsync(id);
            if (type == null)
            {
                return NotFound();
            }
            await this._typesRepository.DeleteAsync(type);

            return NoContent();
        }
    }
}
