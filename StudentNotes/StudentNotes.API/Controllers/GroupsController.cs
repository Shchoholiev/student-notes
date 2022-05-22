using System.Text;
using Microsoft.AspNetCore.Mvc;
using StudentNotes.Application.IRepositories;
using StudentNotes.Application.IServices;
using StudentNotes.Core.Entities;
using StudentNotes.Core.Entities.Identity;

namespace StudentNotes.API.Controllers
{

    // [Authorize]
    [ApiController]
    [Route("api/groups")]
    public class GroupsController : Controller
    {
        private readonly IGenericRepository<Group> _groupsRepository;

        private readonly IUsersService _usersService;

        public GroupsController(IGenericRepository<Group> groupsRepository, IUsersService usersService)
        {
            this._groupsRepository = groupsRepository;
            this._usersService = usersService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var group = await this._groupsRepository.GetOneAsync(id, g => g.Users);
            if (group == null)
            {
                return NotFound();
            }

            return group;
        }


        [HttpGet("by-invite-code/{inviteCode}")]
        public async Task<ActionResult<Group>> GetGroup(string inviteCode)
        {
            var group = await this._groupsRepository.GetAllAsync(g => g.InviteCode == inviteCode, g => g.Users);
            if (group.Count() < 1)
            {
                return NotFound();
            }

            return group.FirstOrDefault();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Group group)
        {
            if (ModelState.IsValid)
            {
                do
                {
                    group.InviteCode = GenerateInviteCode();
                } while (await this._groupsRepository.ExistsAsync(g => g.InviteCode == group.InviteCode));

                if (await this._groupsRepository.ExistsAsync(g => g.Name == group.Name))
                {
                    ModelState.AddModelError(string.Empty, "Group with this name already exists!");
                }
                else
                {
                    group.Users.FirstOrDefault().Roles = new List<Role> { new Role { Id = 1 } };
                    this._groupsRepository.Attach(group);
                    await this._groupsRepository.AddAsync(group);

                    return CreatedAtAction("GetGroup", new {id = group.Id}, group);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] Group group)
        {
            if (ModelState.IsValid)
            {
                if (await this._groupsRepository.ExistsAsync(g => g.Name == group.Name && g.Id != id))
                {
                    ModelState.AddModelError(string.Empty, "Group with this name already exists!");
                }
                else
                {
                    this._groupsRepository.Attach(group);
                    await this._groupsRepository.UpdateAsync(group);
                    return NoContent();
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("refresh-invite-code/{id}")]
        public async Task<IActionResult> RefreshInviteCode(int id, [FromBody] Group group)
        {
            if (ModelState.IsValid)
            {
                do
                {
                    group.InviteCode = GenerateInviteCode();
                } while (await this._groupsRepository.ExistsAsync(g => g.InviteCode == group.InviteCode));

                this._groupsRepository.Attach(group);
                await this._groupsRepository.UpdateAsync(group);
                return NoContent();
            }

            return BadRequest(ModelState);
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

        private string GenerateInviteCode()
        {
            string alphabet = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            var random = new Random();
            var sb = new StringBuilder();
            int position;
            for (int i = 0; i < 10; i++)
            {
                position = random.Next(0, alphabet.Length - 1);
                sb.Append(alphabet[position]);
            }

            return sb.ToString();
        }
    }
} 