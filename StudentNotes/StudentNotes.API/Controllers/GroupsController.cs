using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentNotes.Application.IRepositories;
using StudentNotes.Application.Paging;
using StudentNotes.Core.Entities;

namespace StudentNotes.API.Controllers
{

    // [Authorize]
    [ApiController]
    [Route("api/groups")]
    public class GroupsController : Controller
    {
        private readonly IGenericRepository<Group> _groupsRepository;

        public GroupsController(IGenericRepository<Group> groupsRepository)
        {
            this._groupsRepository = groupsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups([FromQuery] PageParameters pageParameters)
        {
            var groups = await this._groupsRepository.GetPageAsync(pageParameters);
            var metadata = new
            {
                groups.TotalItems,
                groups.PageSize,
                groups.PageNumber,
                groups.TotalPages,
                groups.HasNextPage,
                groups.HasPreviousPage
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return groups;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var group = await this._groupsRepository.GetOneAsync(id, g => g.Name);
            if (group == null)
            {
                return NotFound();
            }

            return group;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Group group)
        {
            if (ModelState.IsValid)
            {
                if (await this._groupsRepository.ExistsAsync(g => g.InviteCode == group.InviteCode))
                {
                    ModelState.AddModelError(String.Empty, "Group with such invite code already exists!");
                }
                else
                {
                    this._groupsRepository.Attach(group);
                    await this._groupsRepository.AddAsync(group);
                    return CreatedAtAction("GetGroup", new { id = group.Id }, group);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Group group)
        {
            if (ModelState.IsValid)
            {
                if (await this._groupsRepository.ExistsAsync(g => g.InviteCode == group.InviteCode))
                {
                    ModelState.AddModelError(String.Empty, "Group with such invite code already exists!");
                }
                else
                {
                    this._groupsRepository.Attach(group);
                    await this._groupsRepository.UpdateAsync(group);
                    return NoContent();
                }
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var group = await this._groupsRepository.GetOneAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            await this._groupsRepository.DeleteAsync(group);
            
            return NoContent();
        }
    }
} 