using StudentNotes.Application.IRepositories;
using Microsoft.AspNetCore.Mvc;
using StudentNotes.Core.Entities.Notes;
using StudentNotes.Application.IServices;
using System.Security.Claims;

namespace StudentNotes.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/notes")]
    public class NotesController : Controller
    {
        private readonly INotesRepository _notesRepository;

        private readonly IUsersService _usersService;

        public NotesController(INotesRepository notesRepository, IUsersService usersService)
        {
            this._notesRepository = notesRepository;
            this._usersService = usersService;
        }

        [HttpGet("day")]
        public async Task<ActionResult<IEnumerable<NoteBase>>> GetNotesByDay([FromQuery] int year, 
                                                        [FromQuery] int month, [FromQuery] int day)
        {
            var date = new DateOnly(year, month, day);
            var email = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await this._usersService.GetAsync(email);
            return Ok(await this._notesRepository.GetDayNotesAsync(date, user.Group));
        }

        [HttpGet("month")]
        public async Task<ActionResult<IEnumerable<NoteBase>>> GetNotesByMonth([FromQuery] int year,
                                                                               [FromQuery] int month)
        {
            var date = new DateOnly(year, month, 1);
            var email = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await this._usersService.GetAsync(email);
            return Ok(await this._notesRepository.GetMonthNotesAsync(date, user.Group));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteBase>> GetNote(int id)
        {
            var note = await this._notesRepository.GetNoteAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            return note;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NoteBase note)
        {
            if (ModelState.IsValid)
            {
                var email = User?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = await this._usersService.GetAsync(email);
                note.Author = user;
                note.Group = user.Group;
                this._notesRepository.Attach(note);
                await this._notesRepository.AddAsync(note);
                return CreatedAtAction("GetNote", new { id = note.Id }, note);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] NoteBase note)
        {
            if (ModelState.IsValid)
            {
                this._notesRepository.Attach(note);
                await this._notesRepository.UpdateAsync(note);
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var note = await this._notesRepository.GetNoteAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            await this._notesRepository.DeleteAsync(note);

            return NoContent();
        }
    }
}
