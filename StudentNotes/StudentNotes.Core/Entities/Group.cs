using System;
using System.Collections.Generic;
using StudentNotes.Core.Entities.Identity;

namespace StudentNotes.Core.Entities
{
    public class Group
    {
        List<User> Users { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        User Headman { get; set; }
        string InviteCode { get; set; }
    }
}
