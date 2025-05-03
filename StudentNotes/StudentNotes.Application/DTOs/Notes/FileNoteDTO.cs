namespace StudentNotes.Application.DTOs.Notes
{
    public class FileNoteDTO : NoteBaseDTO
    {
        public List<StudentNotes.Core.Entities.File> Files { get; set; }
    }
}
