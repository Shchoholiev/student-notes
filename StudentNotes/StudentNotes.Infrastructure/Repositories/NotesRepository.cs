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

        public async Task<NoteBase> GetNoteAsync(int id)
        {
            return await this._table.FirstOrDefaultAsync<NoteBase>(entity => entity.Id == id);
        }

        public async Task UpdateAsync(NoteBase item)
        {
            this._db.Entry(item).State = EntityState.Modified;
            this.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await this._db.SaveChangesAsync();
        }

        public async Task<IEnumerable<NoteBase>> GetMonthNotesAsync(DateOnly month)
        {
            var rawNotes = this._table.AsNoTracking()
                               .Where(date => date.DeadLine.Year == month.Year && date.DeadLine.Month == month.Month);
            var notes = new List<NoteBase>();

            foreach (var note in rawNotes)
            {
                var text = await this._db.TextNotes
                    .AsNoTracking()
                    .Include(t => t.Subject)
                    .Include(t => t.Type)
                    .Include(t => t.Author)
                    .Include(t => t.UsersCompleted)
                    .FirstOrDefaultAsync(t => t.Id == note.Id);

                var file = await this._db.FileNotes
                    .AsNoTracking()
                    .Include(t => t.Subject)
                    .Include(t => t.Type)
                    .Include(t => t.Author)
                    .Include(t => t.UsersCompleted)
                    .Include(f => f.Files)
                    .FirstOrDefaultAsync(f => f.Id == note.Id);
                notes.Add(text ?? file ?? new NoteBase());
            }
            return notes;
        }

        public async Task<IEnumerable<NoteBase>> GetDayNotesAsync(DateOnly day)
        {
            var rawNotes = this._table.AsNoTracking()
                               .Where(date => date.DeadLine.Year == day.Year && date.DeadLine.Month == day.Month && date.DeadLine.Day == day.Day);
            var notes = new List<NoteBase>();

            foreach (var note in rawNotes)
            {
                var text = await this._db.TextNotes
                    .AsNoTracking()
                    .Include(t => t.Subject)
                    .Include(t => t.Type)
                    .Include(t => t.Author)
                    .Include(t => t.UsersCompleted)
                    .FirstOrDefaultAsync(t => t.Id == note.Id);

                var file = await this._db.FileNotes
                    .AsNoTracking()
                    .Include(f => f.Subject)
                    .Include(f => f.Type)
                    .Include(f => f.Author)
                    .Include(f => f.UsersCompleted)
                    .Include(f => f.Files)
                    .FirstOrDefaultAsync(f => f.Id == note.Id);
                notes.Add(text ?? file ?? new NoteBase());
            }
            return notes;
        }
    }
}