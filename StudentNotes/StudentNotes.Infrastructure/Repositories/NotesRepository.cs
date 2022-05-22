using StudentNotes.Application.IRepositories;
using StudentNotes.Core.Entities.Notes;
using Microsoft.EntityFrameworkCore;
using StudentNotes.Infrastructure.ApplicationContext;

namespace StudentNotes.Infrastructure.Repositories
{
    public class NotesRepository : INotesRepository
    {
        public NotesRepository(EFContext dbContext)
        {
            this._db = dbContext;
            this._table = dbContext.Set<NoteBase>();
        }

        private DbSet<NoteBase> _table;

        private EFContext _db;

        public void Attach(params object[] obj)
        {
            this._db.AttachRange(obj);
        }

        public async Task AddAsync(NoteBase item)
        {
            await this._table.AddAsync(item);
            await this.SaveAsync();
        }

        public async Task DeleteAsync(NoteBase item)
        {
            this._table.Remove(item);
            await this.SaveAsync();
        }

        public async Task<NoteBase> GetNoteAsync(int id)
        {
            var rawNote = await this._table.FirstOrDefaultAsync<NoteBase>(entity => entity.Id == id);

            return await NoteSort(rawNote);
        }

        public async Task UpdateAsync(NoteBase item)
        {
            this._table.Update(item);
            await this.SaveAsync();
        }

        public async Task<IEnumerable<NoteBase>> GetMonthNotesAsync(DateOnly month)
        {
            var rawNotes = this._table.AsNoTracking()
                               .Where(date => date.DeadLine.Year == month.Year && date.DeadLine.Month == month.Month);
            var notes = new List<NoteBase>();

            foreach (var note in rawNotes)
            {
                var item = await NoteSort(note);
                notes.Add(item);
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
                var item = await NoteSort(note);
                notes.Add(item);
            }
            return notes;
        }

        private async Task SaveAsync()
        {
            await this._db.SaveChangesAsync();
        }

        private async Task<NoteBase> NoteSort(NoteBase note)
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
            return (text ?? file ?? new NoteBase());
        }
    }
}