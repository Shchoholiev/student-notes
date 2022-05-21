using StudentNotes.Infrastructure.ApplicationContext;

namespace StudentNotes.Infrastructure.DataInitializer
{
    public static class DbInitializer
    {
        public static void Initialize(EFContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
