namespace StudentNotes.Core.Entities.Identity
{
    public class Role : EntityBase
    {
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
