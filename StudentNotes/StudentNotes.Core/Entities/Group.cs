using StudentNotes.Core.Entities.Identity;

namespace StudentNotes.Core.Entities
{
    public class Group : EntityBase
    {
        public string Name { get; set; }

        public string InviteCode { get; set; }

        public List<User> Users { get; set; }
    }
}
