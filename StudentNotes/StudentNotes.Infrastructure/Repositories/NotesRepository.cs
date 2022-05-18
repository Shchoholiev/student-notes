using StudentNotes.Application.IRepositories;
using StudentNotes.Core.Entities.Notes;
using Microsoft.EntityFrameworkCore;
using StudentNotes.Infrastructure.ApplicationContext;

namespace StudentNotes.Infrastructure.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private DbSet<NoteBase> _table;

        private EFContext _db;

        public async Task AddAsync(NoteBase item)
        {
            await this._table.AddAsync(item);
            this.SaveAsync();
        }

        public async Task DeleteAsync(NoteBase item)
        {
            this._table.Remove(item);
            this.SaveAsync();
        }

        public async Task<IEnumerable<NoteBase>> GetAllAsync(DateOnly month)
        {
            var notes = this._table.AsNoTracking().Include(note => note.DeadLine.Month == month).ToList();
            foreach(var entity in notes.OrderBy(en => en.Id))
            {
                var text = await this._db.TextNotes
                    .AsNoTracking()
                    .Include(x => x.Id)
                    .FirstOrDefaultAsync()
            }
        }

        public async Task<IEnumerable<NoteBase>> GetAllAsync(DateOnly day)
        {
            return this._table.AsNoTracking().Include(note => note.DeadLine.Day == day).ToList();
        }

        public async Task<NoteBase> GetNoteAsync(int id)
        {
            return await this._table.FirstOrDefaultAsync<NoteBase>(entity => entity.Id == id);
        }

        public async Task UpdateAsync(NoteBase item)
        {
            _db.Entry(item).State = EntityState.Modified;
            this.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await this._db.SaveChangesAsync();
        }
    }
}
