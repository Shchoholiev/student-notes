using Microsoft.EntityFrameworkCore;
using StudentNotes.Core.Entities;
using StudentNotes.Core.Entities.Identity;
using StudentNotes.Core.Entities.Notes;

namespace StudentNotes.Infrastructure.ApplicationContext
{
    public class EFContext : DbContext
    {
        public EFContext() { }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany<User>(g => g.Users)
                .WithOne(u => u.Group)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Group>()
                .HasIndex(g => g.InviteCode)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users);
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
    }
}