using StudentNotes.Core.Entities;

namespace StudentNotes.Application.DTOs.Notes
{
    public class NoteBaseDTO
    {
        public Core.Entities.Type Type { get; set; }

        public DateTime DeadLine { get; set; }

        public Subject Subject { get; set; }
    }
}
