using StudentNotes.Application.IRepositories;
using StudentNotes.Core.Entities.Notes;

namespace StudentNotes.Infrastructure.Repositories
{
    public class NotesRepository : INotesRepository
    {
        public Task AddAsync(NoteBase item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(NoteBase item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoteBase>> GetAllAsync(int month)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoteBase>> GetAllAsync(DateOnly day)
        {
            throw new NotImplementedException();
        }

        public Task<NoteBase> GetNoteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(NoteBase item)
        {
            throw new NotImplementedException();
        }
    }
}
