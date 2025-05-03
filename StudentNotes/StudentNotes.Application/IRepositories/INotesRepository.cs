using StudentNotes.Core.Entities;
using StudentNotes.Core.Entities.Notes;

namespace StudentNotes.Application.IRepositories
{
    public interface INotesRepository
    {
        Task AddAsync(NoteBase item);

        Task UpdateAsync(NoteBase item);

        Task DeleteAsync(NoteBase item);

        void Attach(params object[] obj);

        Task<NoteBase> GetNoteAsync(int id);

        Task<IEnumerable<NoteBase>> GetMonthNotesAsync(DateOnly month, Group group);

        Task<IEnumerable<NoteBase>> GetDayNotesAsync(DateOnly day, Group group);
    }
}
