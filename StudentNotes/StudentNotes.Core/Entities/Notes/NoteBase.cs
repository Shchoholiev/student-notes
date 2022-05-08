using System;
using System.Collections.Generic;
using StudentNotes.Core.Entities.Identity;

namespace StudentNotes.Core.Entities.Notes
{
    public class NoteBase : EntityBase
    {
        public Type Type { get; set; }
        
        public DateTime DeadLine { get; set; }
        
        public Subject Subject { get; set; }
        
        public List<User> UsersCompleted { get; set; }
        
        public User Author { get; set; }
    }
}