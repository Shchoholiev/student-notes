using StudentNotes.Application.IRepositories;
using Microsoft.AspNetCore.Mvc;
using StudentNotes.Core.Entities.Notes;

namespace StudentNotes.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/notes")]
    public class NotesController : Controller
    {
        private readonly INotesRepository _notesRepository;

        public NotesController(INotesRepository notesRepository)
        {
            this._notesRepository = notesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteBase>>> GetNotesByDay([FromBody] DateOnly day)
        {
            return Ok(await this._notesRepository.GetDayNotesAsync(day));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteBase>>> GetNotesByMonth([FromBody] DateOnly month)
        {
            return Ok(await this._notesRepository.GetMonthNotesAsync(month));
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
