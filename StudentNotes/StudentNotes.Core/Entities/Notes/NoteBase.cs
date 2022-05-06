using System;
using System.Collections.Generic;
using StudentNotes.Core.Entities.Identity;

namespace StudentNotes.Core.Entities.Notes
{
    public class NoteBase
    {
        int Id { get; set; }
        Type Type { get; set; }
        DateTime DeadLine { get; set; }
        Subject Subject { get; set; }
        List<User> UsersCompleted { get; set; }
        User Author { get; set; }
    }
}