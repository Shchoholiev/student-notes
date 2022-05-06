using System;

namespace StudentNotes.Core.Entities.Identity
{
    public class User
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string PasswordHash { get; set; }
        UserToken UserToken { get; set; }
        string Avatar { get; set; }
        Group Group { get; set; }
        List<Role> Roles { get; set; }
    }
}
