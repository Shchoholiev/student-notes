using System;

namespace StudentNotes.Core.Entities
{
    public class Subject : EntityBase
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public Teacher Teacher { get; set; }
    }
}
