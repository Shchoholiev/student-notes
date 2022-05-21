using StudentNotes.Core.Entities.Notes;

namespace StudentNotes.Application.IRepositories
{
    public interface INotesRepository
    {
        Task AddAsync(NoteBase item);

        Task UpdateAsync(NoteBase item);

        Task DeleteAsync(NoteBase item);

        Task<NoteBase> GetNoteAsync(int id);

        Task<IEnumerable<NoteBase>> GetMonthNotesAsync(DateOnly month);

        Task<IEnumerable<NoteBase>> GetDayNotesAsync(DateOnly day);
    }
}
