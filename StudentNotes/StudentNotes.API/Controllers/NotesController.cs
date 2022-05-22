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
        public async Task<ActionResult<IEnumerable<NoteBase>>> GetNotesByDay([FromQuery] DateOnly day)
        {
            return await this._notesRepository.GetDayNotesAsync(day);
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
