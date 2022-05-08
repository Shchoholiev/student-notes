using System;

namespace StudentNotes.Core.Entities
{
    public class Teacher : EntityBase
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Avatar { get; set; }
        
        public List<Subject> Subjects { get; set; }
    }
}
