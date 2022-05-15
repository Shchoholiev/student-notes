using Microsoft.EntityFrameworkCore;
using StudentNotes.Core.Entities;
using StudentNotes.Core.Entities.Identity;
using StudentNotes.Core.Entities.Notes;

namespace StudentNotes.Infrastructure.ApplicationContext
{
    public class EFContext : DbContext
    {
        public EFContext()
        {
           
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserToken> UserTokens { get; set; }

        public DbSet<FileNote> FileNotes { get; set; }

        public DbSet<TextNote> TextNotes { get; set; }

        public DbSet<NoteBase> NoteBases { get; set; }

        public DbSet<Core.Entities.Type> Types { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Core.Entities.File> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudentNotes;Trusted_Connection=True;");
        }
    }
}