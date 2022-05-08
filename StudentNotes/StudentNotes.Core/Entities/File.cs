using System;

namespace StudentNotes.Core.Entities
{
    public class File : EntityBase
    {
        public int Id { get; set; }
        
        public string Link { get; set; }
        
        public string Name { get; set; }
    }
}
