namespace StudentNotes.Core.Entities.Identity
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string PasswordHash { get; set; }
        
        public UserToken UserToken { get; set; }
        
        public string Avatar { get; set; }
        
        public Group Group { get; set; }
        
        public List<Role> Roles { get; set; }
    }
}
